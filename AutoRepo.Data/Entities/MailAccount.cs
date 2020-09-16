using System;
using System.ComponentModel.DataAnnotations;

namespace AutoRepo.Data.Entities
{
    public class MailAccount
    {
        [Key]
        public Guid IdMailAccount { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        [MaxLength(50)]
        public string Server { get; set; }
        public int Port { get; set; }

        [MaxLength(50)]
        public string Username { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }
        public bool UseSSL { get; set; }
    }
}