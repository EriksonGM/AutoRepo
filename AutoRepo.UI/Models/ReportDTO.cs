using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoRepo.UI.Models
{
    public class ReportDTO
    {
        public Guid? IdReport { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string Subject { get; set; }

        [Required]
        public string Boby { get; set; }


        public bool IsHtml { get; set; }

        [Display(Name = "Mail Account")]
        [BindProperty]
        public Guid IdMailAccount { get; set; }

        public string Mail { get; set; }

        public MailAccountDTO MailAccount { get; set; }

        public List<SelectListItem> MailAccountList { get; set; } = new List<SelectListItem>();
    }
}
