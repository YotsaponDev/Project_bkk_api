using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Models;

namespace Project_bkk_api.Models.Laws
{
    public interface ILaws
    {
        List<LawsEntity> GetAll();
        LawsEntity GetById(Guid id);
        LawsEntity Create(LawsEntity model);
        LawsEntity Update(Guid id, LawsEntity modelUpdate);
        LawsEntity Delete(Guid id);
    }
}
