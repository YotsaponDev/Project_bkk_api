using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Models;

namespace Project_bkk_api.Models.Staff
{
    public interface IStaff
    {
        List<StaffEntity> GetAll();
        StaffEntity GetById(Guid id);
        StaffReturnViewModel GetByIdViaJWT(string authHeader);
        StaffEntity Create(StaffEntity model);
        StaffEntity Update(Guid id, StaffEntity modelUpdate);
        StaffEntity Delete(Guid id);
        object Login(StaffLoginViewModel model);
    }
}
