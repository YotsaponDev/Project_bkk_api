using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Models
{
    public class LawsViewModel
    {
        public Guid id { get; set; }

        public string name { get; set; }

        public string note { get; set; }

        public bool is_active { get; set; }

        public Guid? created_by { get; set; }

        public DateTime? created_at { get; set; }

        public Guid? updated_by { get; set; }

        public DateTime? updated_at { get; set; }

        public DateTime? deleted_at { get; set; }

    }
}
