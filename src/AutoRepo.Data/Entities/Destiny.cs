using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoRepo.Data.Entities
{
    public class Destiny
    {
        [Key]
        public Guid IdDestiny { get; set; }


        public Guid IdReport { get; set; }

        [ForeignKey("IdReport")]
        public Report Report { get; set; }

        public string Email { get; set; }
    }
}