using Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Project_bkk_api.Models.Permission;
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
    public class PermissionRepository : IPermission
    {
        private DataContext _context;

        private IConfiguration configuration;

        public PermissionRepository(DataContext context, IConfiguration iConfig)
        {
            _context = context;
            configuration = iConfig;
        }

        public List<PermissionEntity> GetAll()
        {
            return _context.permission.Where(x => x.deleted_at == null).ToList();
        }

        public PermissionEntity GetById(Guid id)
        {
            return _context.permission.Find(id);
        }

        public PermissionEntity Create(PermissionEntity model)
        {
            model.id = Guid.NewGuid();
            model.deleted_at = null;
            _context.permission.Add(model);
            _context.SaveChanges();
            return model;
        }

        public PermissionEntity Update(Guid id, PermissionEntity modelUpdate)
        {
            var data = _context.permission.Find(id);

            data.name = modelUpdate.name;
            data.note = modelUpdate.note;
            data.is_active = modelUpdate.is_active;
            //data.created_by = modelUpdate.created_by;
            //data.created_at = modelUpdate.created_at;
            data.updated_at = DateTime.Now;

            _context.SaveChanges();

            return data;
        }

        public PermissionEntity Delete(Guid id)
        {
            var data = _context.permission.Find(id);

            data.deleted_at = DateTime.Now;

            _context.SaveChanges();

            return data;
        }  
    }
}
