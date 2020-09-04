using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AutoRepo.UI.Controllers
{
    public class MailAccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
