using Core.Data;
using Microsoft.EntityFrameworkCore;
using Project_bkk_api.Models.Laws;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Models
{
    public class LawsRepository : ILaws
    {
        private DataContext _context;

        public LawsRepository(DataContext context)
        {
            _context = context;
        }

        public List<LawsEntity> GetAll()
        {
            return _context.laws.ToList();
        }

        public LawsEntity GetById(Guid id)
        {
            return _context.laws.Find(id);
        }

        public LawsEntity Create(LawsEntity model)
        {
            model.delete_at = null;
            _context.laws.Add(model);
            _context.SaveChanges();

            return model;
        }

        public LawsEntity Update(LawsEntity modelUpdate)
        {
            throw new NotImplementedException();
        }

        public LawsEntity Delete(Guid id)
        {
            throw new NotImplementedException();
        }  
    }
}
