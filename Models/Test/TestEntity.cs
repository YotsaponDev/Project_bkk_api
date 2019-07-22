using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_bkk_api.Models.Test
{
    public class TestEntity
    {
        [Key]
        public Guid id { get; set; }

        [MaxLength(255)]
        public string fullname { get; set; }

        public int age { get; set; }

        [MaxLength(200)]
        public string email { get; set; }

        public DateTime? date { get; set; }

        public string address { get; set; }

        [MaxLength(2000)]
        public string remark { get; set; }
    }
}
