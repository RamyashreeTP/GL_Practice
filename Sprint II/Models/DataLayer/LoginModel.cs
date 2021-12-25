using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Models
{
    public class LoginModel
    {
        [Key]
        public string userName { get; set; }
        public string userPassword { get; set; }
    }
}

