using Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Project_bkk_api.Models.Staff;
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
    public class StaffRepository : IStaff
    {
        private DataContext _context;

        private IConfiguration configuration;

        public StaffRepository(DataContext context, IConfiguration iConfig)
        {
            _context = context;
            configuration = iConfig;
        }

        public List<StaffEntity> GetAll()
        {
            return _context.staff.Where(x => x.deleted_at == null).ToList();
        }

        public StaffEntity GetById(Guid id)
        {
            return _context.staff.Find(id);
        }

        public StaffReturnViewModel GetByIdViaJWT(string authHeader)
        {
            var handler = new JwtSecurityTokenHandler();
            string[] auth = authHeader.Split(" ");

            var exp = handler.ReadJwtToken(auth[1]).Payload.Exp;

            DateTime now = DateTime.Now;
            var date = now;

            var lifeTime = new JwtSecurityTokenHandler().ReadToken(auth[1]).ValidTo.ToLocalTime();

            var id = handler.ReadJwtToken(auth[1]).Payload.Jti;
            var staff = _context.staff.Find(Guid.Parse(id));
            var data = new StaffReturnViewModel();
            data.id = staff.id;
            data.firstname = staff.firstname;
            data.lastname = staff.lastname;
            data.username = staff.username;
            data.email = staff.email;

            return data;
        }

        public StaffEntity Create(StaffEntity model)
        {

            var staff = _context.staff.Where(x => x.username == model.username || x.email == model.email).FirstOrDefault();

            if(staff == null)
            {
                model.id = Guid.NewGuid();
                model.deleted_at = null;
                model.password = StringToMD5(model.password);
                _context.staff.Add(model);
                _context.SaveChanges();

                model.password = null;
                return model;
            }
            else
            {
                if (staff.username == model.username)
                {
                    throw new Exception("Username already exists");
                } else if (staff.email == model.email)
                {
                    throw new Exception("Email already exists");
                }
                else
                {
                    throw new Exception("Username and Email already exists");
                }
                
            } 
        }

        public object Login(StaffLoginViewModel model)
        {
            var checkPassword = StringToMD5(model.password);
            var staff = _context.staff.Where(x => x.username == model.username && x.password == checkPassword).FirstOrDefault();

            if (staff == null)
            {
                throw new Exception();
            }
            else
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, staff.id.ToString())
                    //new Claim(JwtRegisteredClaimNames.NameId, user.username),
                    //new Claim(JwtRegisteredClaimNames.GivenName, user.firstname),
                    //new Claim(JwtRegisteredClaimNames.FamilyName, user.lastname),
                    //new Claim(JwtRegisteredClaimNames.Email, user.email)
                };
                string key = configuration.GetSection("JWT").GetSection("SecurityKey").Value;
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

                var token = new JwtSecurityToken(
                    expires: DateTime.Now.AddSeconds(5),
                    claims: claims,
                    signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                    );

                // find role
                var role_name = (from shr in _context.staff_has_role where shr.staff_id == staff.id 
                          join r in _context.role on shr.role_id equals r.id into r2
                          from f in r2.DefaultIfEmpty()
                          select new  {
                            f.name,f.id
                           }).ToList();

                List<string> roleNameArr = new List<string>();
                List<string> permissionNameArr = new List<string>();

                if (role_name != null)
                {
                    int rnC = role_name.Count;
                    for (int i = 0; i < rnC; i++)
                    {
                     
                        // find permission
                        var pn = (from rhp in _context.role_has_permission
                                  where rhp.role_id == role_name[i].id
                                  join p in _context.permission on rhp.permission_id equals p.id into p2
                                  from f in p2.DefaultIfEmpty()
                                  select new
                                  {
                                      f.name,
                                      f.id
                                  }).ToList();
                        int pnC = pn.Count;
                        for (int j = 0; j < pnC; j++)
                        {
                            permissionNameArr.Add(pn[j].name);
                        }
                    }
                }
                string[] roleNameArray = roleNameArr.ToArray();
                string[] permissionNameArray = permissionNameArr.ToArray();

                var return_token = new {
                    access_token = new JwtSecurityTokenHandler().WriteToken(token),
                    role = roleNameArray,
                    permission = permissionNameArray
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

        public StaffEntity Update(Guid id, StaffEntity modelUpdate)
        {
            var data = _context.staff.Find(id);

            data.firstname = modelUpdate.firstname;
            data.lastname = modelUpdate.lastname;
            data.is_active = modelUpdate.is_active;
            //data.created_by = modelUpdate.created_by;
            //data.created_at = modelUpdate.created_at;
            data.updated_at = DateTime.Now;

            _context.SaveChanges();

            return data;
        }

        public StaffEntity Delete(Guid id)
        {
            var data = _context.staff.Find(id);

            data.deleted_at = DateTime.Now;

            _context.SaveChanges();

            return data;
        }  
    }
}
