using Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Project_bkk_api.Models.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Models
{
    public class UserRepository : IUser
    {
        private DataContext _context;

        private IConfiguration configuration;

        public UserRepository(DataContext context, IConfiguration iConfig)
        {
            _context = context;
            configuration = iConfig;
        }

        public List<UserEntity> GetAll()
        {
            return _context.user.Where(x => x.deleted_at == null).ToList();
        }

        public UserEntity GetById(Guid id)
        {
            return _context.user.Find(id);
        }

        public UserEntity Create(UserEntity model)
        {

            var user = _context.user.Where(x => x.username == model.username || x.email == model.email).First();

            if(user == null)
            {
                model.id = Guid.NewGuid();
                model.deleted_at = null;
                model.password = StringToMD5(model.password);
                _context.user.Add(model);
                _context.SaveChanges();

                model.password = null;
                return model;
            }
            else
            {
                if (user.username == model.username)
                {
                    throw new Exception("Username already exists");
                } else if (user.email == model.email)
                {
                    throw new Exception("Email already exists");
                }
                else
                {
                    throw new Exception("Username and Email already exists");
                }
                
            } 
        }

        public object Login(LoginViewModel model)
        {
            var checkPassword = StringToMD5(model.password);
            var user = _context.user.Where(x => x.username == model.username && x.password == checkPassword).First();

            if (user == null)
            {
                throw new Exception();
            }
            else
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.NameId, user.username),
                    new Claim(JwtRegisteredClaimNames.GivenName, user.firstname),
                    new Claim(JwtRegisteredClaimNames.FamilyName, user.lastname),
                    new Claim(JwtRegisteredClaimNames.Email, user.email)
                };
                string key = configuration.GetSection("JWT").GetSection("SecurityKey").Value;
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

                var token = new JwtSecurityToken(
                    expires: DateTime.Now.AddHours(1),
                    claims: claims,
                    signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                    );

                var return_token = new {
                    jwt_token = new JwtSecurityTokenHandler().WriteToken(token),
                };

                return return_token;
            }   
        }

        static string StringToMD5(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }

        public UserEntity Update(Guid id, UserEntity modelUpdate)
        {
            var data = _context.user.Find(id);

            data.firstname = modelUpdate.firstname;
            data.lastname = modelUpdate.lastname;
            data.is_active = modelUpdate.is_active;
            //data.created_by = modelUpdate.created_by;
            //data.created_at = modelUpdate.created_at;
            data.updated_at = DateTime.Now;

            _context.SaveChanges();

            return data;
        }

        public UserEntity Delete(Guid id)
        {
            var data = _context.user.Find(id);

            data.deleted_at = DateTime.Now;

            _context.SaveChanges();

            return data;
        }  
    }
}
