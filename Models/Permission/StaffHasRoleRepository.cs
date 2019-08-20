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
    public class StaffHasRoleRepository : IStaffHasRole
    {
        private DataContext _context;

        private IConfiguration configuration;

        public StaffHasRoleRepository(DataContext context, IConfiguration iConfig)
        {
            _context = context;
            configuration = iConfig;
        }

        public List<StaffHasRoleEntity> GetAll()
        {
            return _context.staff_has_role.Where(x => x.deleted_at == null).ToList();
        }

        public StaffHasRoleEntity GetById(Guid id)
        {
            return _context.staff_has_role.Find(id);
        }

        public StaffHasRoleViewModel Create(StaffHasRoleViewModel model)
        {
            var shrEn = new StaffHasRoleEntity();
            shrEn.id = Guid.NewGuid();
            shrEn.role_id = model.role_id;
            shrEn.staff_id = model.staff_id;
            shrEn.is_active = model.is_active;
            shrEn.created_by = model.created_by;
            shrEn.created_at = model.created_at;
            shrEn.updated_at = model.updated_at;
            shrEn.updated_by = model.updated_by;
            
            _context.staff_has_role.Add(shrEn);
            _context.SaveChanges();

            model.id = shrEn.id;
            return model;
        }

        //public StaffHasRoleEntity Update(Guid id, StaffHasRoleEntity modelUpdate)
        //{
        //    var data = _context.staff_has_role.Find(id);

        //    //data.created_by = modelUpdate.created_by;
        //    //data.created_at = modelUpdate.created_at;
        //    data.updated_at = DateTime.Now;

        //    _context.SaveChanges();

        //    return data;
        //}

        public StaffHasRoleEntity Delete(Guid id)
        {
            var data = _context.staff_has_role.Find(id);

            data.deleted_at = DateTime.Now;

            _context.SaveChanges();

            return data;
        }  
    }
}
