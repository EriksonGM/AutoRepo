using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoRepo.Data;
using AutoRepo.Data.Entities;
using AutoRepo.UI.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoRepo.UI.Services
{
    public interface IReportService
    {
        public bool Exist(Guid idReport);

        public List<ReportDTO> GetAll(string filtro, int page = 0);

        public bool Add(ReportDTO dto);

        public bool Update(ReportDTO dto);

        public ReportDTO Get(Guid id);
    }

    public class ReportService : IReportService
    {
        private readonly DataContext _db;
        public ReportService(DataContext db)
        {
            _db = db;
        }

        public bool Exist(Guid idReport)
        {
            return _db.Reports.Any(x => x.IdReport == idReport);
        }

        public List<ReportDTO> GetAll(string filtro, int page = 0)
        {
            var qry = _db.Reports
                .AsQueryable().AsNoTracking();

            if (!string.IsNullOrEmpty(filtro))
                qry = qry.Where(x => x.Description.Contains(filtro));

            var res = qry.OrderBy(x => x.Description)
                .Skip(page * 10)
                .Take(10)
                .Select(x => new ReportDTO())
                .ToList();

            return res;
        }

        public bool Add(ReportDTO dto)
        {
            var report = new Report
            {
                IdReport = Guid.NewGuid(),
                IdMailAccount = dto.IdMailAccount,
                Description = dto.Description,
                Subject = dto.Subject,
                Boby = dto.Boby,
                IsHtml = dto.IsHtml
            };

            _db.Reports.Add(report);

            _db.SaveChanges();

            return true;
        }

        public bool Update(ReportDTO dto)
        {
            var report = _db.Reports
                .FirstOrDefault(X => X.IdMailAccount == dto.IdReport.Value);

            report.Description = dto.Description;
            report.Subject = dto.Subject;
            report.Boby = dto.Boby;
            report.IsHtml = dto.IsHtml;
            report.IdMailAccount = dto.IdMailAccount;

            _db.Update(report);

            _db.SaveChanges();
            
            return true;
        }

        public ReportDTO Get(Guid id)
        {
            var report = _db.Reports.Include(x => x.MailAccount).FirstOrDefault(X => X.IdMailAccount == id);

            if (report == null)
                return null;

            var dto = new ReportDTO
            {
                IdReport = report.IdReport,
                Description = report.Description,
                Subject = report.Subject,
                IdMailAccount = report.IdMailAccount,
                MailAccount = new MailAccountDTO
                {
                    IdMailAccount = report.IdMailAccount,
                    Description = report.MailAccount.Description,
                    Server = report.MailAccount.Server,
                    Port = report.MailAccount.Port,
                    Username = report.MailAccount.Username,
                    Password = report.MailAccount.Password,
                    UseSSL = report.MailAccount.UseSSL
                },
                Boby = report.Boby,
                IsHtml = report.IsHtml
            };

            return dto;
        }
    }
}
