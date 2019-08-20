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
    public class RoleHasPermissionRepository : IRoleHasPermission
    {
        private DataContext _context;

        private IConfiguration configuration;

        public RoleHasPermissionRepository(DataContext context, IConfiguration iConfig)
        {
            _context = context;
            configuration = iConfig;
        }

        public List<RoleHasPermissionEntity> GetAll()
        {
            return _context.role_has_permission.Where(x => x.deleted_at == null).ToList();
        }

        public RoleHasPermissionEntity GetById(Guid id)
        {
            return _context.role_has_permission.Find(id);
        }

        public RoleHasPermissionViewModel Create(RoleHasPermissionViewModel model)
        {
            var r = new RoleHasPermissionEntity();
            r.id = Guid.NewGuid();
            r.role_id = model.role_id;
            r.permission_id = model.permission_id;
            r.is_active = model.is_active;
            r.created_by = model.created_by;
            r.created_at = model.created_at;
            r.updated_at = model.updated_at;
            r.updated_by = model.updated_by;

            _context.role_has_permission.Add(r);
            _context.SaveChanges();

            model.id = r.id;
            return model;
        }

        //public RoleHasPermissionEntity Update(Guid id, RoleHasPermissionEntity modelUpdate)
        //{
        //    var data = _context.role_has_permission.Find(id);

        //    data.name = modelUpdate.name;
        //    data.note = modelUpdate.note;
        //    data.is_active = modelUpdate.is_active;
        //    //data.created_by = modelUpdate.created_by;
        //    //data.created_at = modelUpdate.created_at;
        //    data.updated_at = DateTime.Now;

        //    _context.SaveChanges();

        //    return data;
        //}

        public RoleHasPermissionEntity Delete(Guid id)
        {
            var data = _context.role_has_permission.Find(id);

            data.deleted_at = DateTime.Now;

            _context.SaveChanges();

            return data;
        }  
    }
}
