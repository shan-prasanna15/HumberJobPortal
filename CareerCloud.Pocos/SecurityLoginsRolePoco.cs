﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Security_Logins_Roles")]
    class SecurityLoginsRolePoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Login { get; set; }
        public Guid Role { get; set; }
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }
    }
}
