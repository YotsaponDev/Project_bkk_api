using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Models
{
    public class StaffViewModel
    {
        public Guid id { get; set; }

        public string fullname { get; set; }

        public int position { get; set; }

        public string ad_username { get; set; }

        public string password { get; set; }

        public string email { get; set; }
         
        public string tel { get; set; }

        public bool? is_active { get; set; }

        public Guid? created_by { get; set; }
        
        public DateTime? created_at { get; set; }

        public Guid? updated_by { get; set; }

        public DateTime? updated_at { get; set; }

        public DateTime? delete_at { get; set; }

    }
}
