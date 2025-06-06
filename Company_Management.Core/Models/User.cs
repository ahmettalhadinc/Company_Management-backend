﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_Management.Core.Models
{
    public class User:BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }

        public int RoleId { get; set; }              
        public Role Role { get; set; }
    }
}
