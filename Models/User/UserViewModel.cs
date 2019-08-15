using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Models
{
    public class UserViewModel
    {
        public Guid id { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }

        public string full_company_name { get; set; }

        public string type { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public string email { get; set; }

        public bool is_active { get; set; }

        public DateTime? created_at { get; set; }

        public DateTime? updated_at { get; set; }

        public DateTime? deleted_at { get; set; }

    }
}
