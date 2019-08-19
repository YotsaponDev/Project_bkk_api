using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Models
{
    public class UserReturnViewModel
    {
        public Guid id { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }

        public string full_company_name { get; set; }

        public string type { get; set; }

        public string username { get; set; }

        public string email { get; set; }
    }
}
