using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoRepo.Data;
using AutoRepo.UI.Models;
using AutoRepo.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoRepo.UI.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        private readonly IMailAccountService _mailAccountService;

        public ReportController(IReportService reportService, IMailAccountService mailAccountService)
        {
            _reportService = reportService;
            _mailAccountService = mailAccountService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(Guid? id)
        {
            if (id.HasValue)
            {
                var dto = _reportService.Get(id.Value);

                if (dto == null)
                    return NotFound();

                return View(dto);
            }
            else
            {
                var dto = new ReportDTO
                {
                    MailAccountList = _mailAccountService.List()
                };

                return View(dto);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ReportDTO dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (dto.IdReport.HasValue)
                    {
                        var res = _reportService.Update(dto);

                        if (res)
                            return RedirectToAction("Index");

                        return View(dto);
                    }
                    else
                    {
                        var res = _reportService.Add(dto);

                        if (res)
                            return RedirectToAction("Index");

                        return View(dto);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return View(dto);
        }

        [HttpPost]
        public IActionResult Test(ReportDTO dto)
        {
            if (ModelState.IsValid)
            {
                try
                {

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return View(dto);
        }
    }
}
