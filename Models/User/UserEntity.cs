using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Models
{
    public class UserEntity
    {
        [Key]
        public Guid id { get; set; }

        [Description("ชื่อ")]
        [MaxLength(255)]
        public string firstname { get; set; }

        [Description("นามสกุล")]
        [MaxLength(255)]
        public string lastname { get; set; }

        [Description("ชื่อบริษัทหรือนิติบุคคล")]
        [MaxLength(255)]
        public string full_company_name { get; set; }

        [Description("ประเภทนิติบุคคล")]
        [MaxLength(255)]
        public string type { get; set; }

        [Description("ชื่อผู้ใช้งาน")]
        [MaxLength(255)]
        public string username { get; set; }

        [Description("รหัสผ่าน")]
        [MaxLength(255)]
        public string password { get; set; }

        [Description("อีเมล์")]
        [MaxLength(255)]
        public string email { get; set; }

        [Description("สถานะการใช้งาน")]
        public bool is_active { get; set; }

        [Description("อีเมล์")]
        public DateTime? created_at { get; set; }

        [Description("วันเวลาที่แก้ไข")]
        public DateTime? updated_at { get; set; }

        [Description("วันเวลาที่ลบ")]
        public DateTime? deleted_at { get; set; }

    }
}
