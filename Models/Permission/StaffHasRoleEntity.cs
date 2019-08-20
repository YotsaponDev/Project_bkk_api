using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Models
{
    public class StaffHasRoleEntity
    {
        [Key]
        public Guid id { get; set; }

        [ForeignKey("staff_id")]
        public StaffEntity Staff { get; set; }
        public Guid staff_id { get; set; }

        [ForeignKey("role_id")]
        public RoleEntity Role { get; set; }
        public Guid role_id { get; set; }

        public bool is_active { get; set; }

        public Guid? created_by { get; set; }

        public DateTime? created_at { get; set; }

        public Guid? updated_by { get; set; }

        public DateTime? updated_at { get; set; }

        public DateTime? deleted_at { get; set; }
    }
}
