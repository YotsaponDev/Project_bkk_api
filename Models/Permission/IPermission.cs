using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Models;

namespace Project_bkk_api.Models.Permission
{
    public interface IPermission
    {
        List<PermissionEntity> GetAll();
        PermissionEntity GetById(Guid id);
        PermissionEntity Create(PermissionEntity model);
        PermissionEntity Update(Guid id, PermissionEntity modelUpdate);
        PermissionEntity Delete(Guid id);
    }
}
