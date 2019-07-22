using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_bkk_api.Models.Test
{
    public class TestViewModel
    {
        public Guid id { get; set; }

        public string fullname { get; set; }

        public int age { get; set; }

        public string email { get; set; }

        public DateTime? date { get; set; }

        public string address { get; set; }

        public string remark { get; set; }
    }
}
