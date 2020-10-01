using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoRepo.UI.Models
{
    public class MailAccountDTO
    {
        public Guid? IdMailAccount { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        [Required]
        public string Server { get; set; }

        [Required]
        public int Port { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public bool UseSSL { get; set; }

        
    }
}
