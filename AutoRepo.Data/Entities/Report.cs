using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoRepo.Data.Entities
{
    public class Report
    {
        [Key]
        public Guid IdReport { get; set; }

        public string Description { get; set; }

        public string Subject { get; set; }

        public string Boby { get; set; }

        public bool IsHtml { get; set; }

        public Guid IdMailAccount { get; set; }

        [ForeignKey("IdMailAccount")]
        public MailAccount MailAccount { get; set; }

        public ICollection<Destiny> Destinies = new List<Destiny>();
    }
}