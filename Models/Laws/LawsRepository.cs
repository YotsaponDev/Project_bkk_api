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
            return _context.laws.Where(x => x.deleted_at == null).ToList();
        }

        public LawsEntity GetById(Guid id)
        {
            return _context.laws.Find(id);
        }

        public LawsEntity Create(LawsEntity model)
        {
            model.id = Guid.NewGuid();
            model.deleted_at = null;
            _context.laws.Add(model);
            _context.SaveChanges();

            return model;
        }

        public LawsEntity Update(Guid id, LawsEntity modelUpdate)
        {
            var data = _context.laws.Find(id);

            data.name = modelUpdate.name;
            data.note = modelUpdate.note;
            data.is_active = modelUpdate.is_active;
            //data.created_by = modelUpdate.created_by;
            //data.created_at = modelUpdate.created_at;
            data.updated_by = modelUpdate.updated_by;
            data.updated_at = DateTime.Now;

            _context.SaveChanges();

            return data;
        }

        public LawsEntity Delete(Guid id)
        {
            var data = _context.laws.Find(id);

            data.deleted_at = DateTime.Now;

            _context.SaveChanges();

            return data;
        }  
    }
}
