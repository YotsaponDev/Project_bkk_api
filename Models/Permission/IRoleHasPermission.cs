using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Models;

namespace Project_bkk_api.Models.Permission
{
    public interface IRoleHasPermission
    {
        List<RoleHasPermissionEntity> GetAll();
        RoleHasPermissionEntity GetById(Guid id);
        RoleHasPermissionViewModel Create(RoleHasPermissionViewModel model);
        //RoleHasPermissionEntity Update(Guid id, RoleHasPermissionEntity modelUpdate);
        RoleHasPermissionEntity Delete(Guid id);
    }
}
