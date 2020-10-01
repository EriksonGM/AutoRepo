using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoRepo.Data;
using AutoRepo.Data.Entities;
using AutoRepo.UI.Helpers;
using AutoRepo.UI.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AutoRepo.UI.Services
{
    public interface IMailAccountService
    {
        public bool Exist(Guid idMailAccount);

        public List<SelectListItem> List();

        public bool Add(MailAccountDTO dto);

        public bool Update(MailAccountDTO dto);

        //public List<MailAccountDTO> GetAll(string filter = null, int page = 1);
        public DataCollection<MailAccountDTO> GetAll(int page = 1);

        //public DataCollection<MailAccountDTO> GetPaginated(string filter = null, int page = 1);
    }

    public class MailAccountService : IMailAccountService
    {
        private readonly DataContext _db;
        public MailAccountService(DataContext db)
        {
            _db = db;
        }

        public bool Exist(Guid idMailAccount)
        {
            return _db.MailAccounts.Any(x => x.IdMailAccount == idMailAccount);
        }

        public List<SelectListItem> List()
        {

            return _db.MailAccounts.Select(x => new SelectListItem
            {
                Value = x.IdMailAccount.ToString(),
                Text = x.Description
            }).ToList();

        }

        public bool Add(MailAccountDTO dto)
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

            _db.MailAccounts.Add(mail);

            _db.SaveChanges();

            return true;
        }

        public bool Update(MailAccountDTO dto)
        {
            var mail = _db.MailAccounts.Find(dto.IdMailAccount.Value);

            mail.Description = dto.Description;
            mail.Server = dto.Server;
            mail.Port = dto.Port;
            mail.Username = dto.Username;
            mail.Password = dto.Password;
            mail.UseSSL = dto.UseSSL;

            //db.Entry(mail).State = EntityState.Modified;

            _db.Update(mail);

            _db.SaveChanges();

            return true;
        }

        //public List<MailAccountDTO> GetAll(string filter = null, int page = 0)
        //{
        //    var qry = _db.MailAccounts.AsNoTracking().AsQueryable();

        //    if (!string.IsNullOrEmpty(filter))
        //        qry = qry.Where(x => x.Description.Contains(filter));

        //    var res = qry
        //        .OrderBy(x => x.Description)
        //        .Skip((page - 1) * 10)
        //        .Select(x => new MailAccountDTO
        //        {
        //            IdMailAccount = x.IdMailAccount,
        //            Description = x.Description,
        //            Server = x.Server,
        //            Port = x.Port,
        //            Username = x.Username,
        //            Password = x.Password,
        //            UseSSL = x.UseSSL
        //        }).ToList();

        //    return res;
        //}

        public DataCollection<MailAccountDTO> GetAll(int page = 1)
        {
            var qry = _db.MailAccounts.AsQueryable().AsNoTracking();

            return qry.Select(x => new MailAccountDTO
            {
                IdMailAccount = x.IdMailAccount,
                Description = x.Description,
                Server = x.Server,
                Port = x.Port,
                Username = x.Username,
                Password = x.Password,
                UseSSL = x.UseSSL
            }).ToDataCollection(page, 10);
        }

    }
}
