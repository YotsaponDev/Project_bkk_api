using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Models;

namespace Project_bkk_api.Models.Permission
{
    public interface IStaffHasRole
    {
        List<StaffHasRoleEntity> GetAll();
        StaffHasRoleEntity GetById(Guid id);
        StaffHasRoleViewModel Create(StaffHasRoleViewModel model);
        //StaffHasRoleEntity Update(Guid id, StaffHasRoleEntity modelUpdate);
        StaffHasRoleEntity Delete(Guid id);
    }
}
