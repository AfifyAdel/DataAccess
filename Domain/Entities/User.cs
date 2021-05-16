using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("id", TypeName = "bigint")]
        public long ID { get; set; }

        [MaxLength(50)]
        [Column("username", TypeName = "character varying")]
        public string Username { get; set; }

        [MaxLength(50)]
        [Column("password", TypeName = "character varying")]
        public string Password { get; set; }

        [MaxLength(50)]
        [Column("fullname", TypeName = "character varying")]
        public string FullName { get; set; }

        [Column("role", TypeName = "integer")]
        public int? Role { get; set; }
    }
}
