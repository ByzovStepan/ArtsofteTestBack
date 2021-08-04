using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArtsofteTestBack.Models
{
    public class User
    {
        
        public int Id { get; set; }

        
        public string FIO { get; set; }

        
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        
        [DataType(DataType.Password)]
        public string Password { get; set; }

        
        [DataType(DataType.DateTime)]
        public DateTime LastLogin { get; set; }
    }
}
