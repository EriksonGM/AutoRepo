using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoRepo.Data;
using AutoRepo.Data.Entities;
using AutoRepo.UI.Models;
using AutoRepo.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace AutoRepo.UI.Controllers
{
    public class MailAccountController : Controller
    {
        private readonly IMailAccountService _mailService;
        public MailAccountController(IMailAccountService mailService)
        {
            _mailService = mailService;
        }
        
        //public IActionResult Index()
        //{
        //    var model = _mailService.GetAll();

        //    return View(model);
        //}

        [HttpGet]
        public IActionResult Index(int id = 1)
        {
            var model = _mailService.GetAll(id);

            return View(model);
        }

        public IActionResult Test(MailAccountDTO dto)
        {
            return RedirectToAction("Create", dto);
        }

        public IActionResult Create(Guid? id)
        {
            if (id.HasValue)
            {
                var mail = new DataContext().MailAccounts.Find(id.Value);

                var dto = new MailAccountDTO
                {
                    IdMailAccount = mail.IdMailAccount,
                    Description = mail.Description,
                    Server = mail.Server,
                    Port = mail.Port,
                    Username = mail.Username,
                    Password = mail.Password,
                    UseSSL = mail.UseSSL
                };

                return View(dto);
            }

            return View(new MailAccountDTO());
        }

        [HttpPost]
        public IActionResult Create(MailAccountDTO dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var db = new DataContext();

                    if (dto.IdMailAccount.HasValue)
                    {
                        var mail = db.MailAccounts.Find(dto.IdMailAccount.Value);

                        mail.Description = dto.Description;
                        mail.Server = dto.Server;
                        mail.Port = dto.Port;
                        mail.Username = dto.Username;
                        mail.Password = dto.Password;
                        mail.UseSSL = dto.UseSSL;

                        //db.Entry(mail).State = EntityState.Modified;

                        db.Update(mail);

                        db.SaveChanges();
                    }
                    else
                    {
                        var mail = new MailAccount
                        {
                            IdMailAccount = Guid.NewGuid(),
                            Description = dto.Description,
                            Server = dto.Server,
                            Port = dto.Port,
                            Username = dto.Username,
                            Password = dto.Password,
                            UseSSL = dto.UseSSL
                        };



                        db.MailAccounts.Add(mail);

                        db.SaveChanges();
                    }



                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);

                    Console.WriteLine(e);
                    //throw;
                }

            }

            return View(dto);
        }

    }
}
