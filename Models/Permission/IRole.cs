using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Models;

namespace Project_bkk_api.Models.Permission
{
    public interface IRole
    {
        List<RoleEntity> GetAll();
        RoleEntity GetById(Guid id);
        RoleEntity Create(RoleEntity model);
        RoleEntity Update(Guid id, RoleEntity modelUpdate);
        RoleEntity Delete(Guid id);
    }
}
