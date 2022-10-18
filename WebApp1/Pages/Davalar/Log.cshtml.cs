using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApp1.Models;

namespace WebApp1.Pages.Davalar
{
    [Authorize]
    public class LogModel : PageModel
    {

        private readonly HukukDTSContext _context;
        private readonly IConfiguration _configuration;

        public LogModel(HukukDTSContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public IQueryable<LogTable> logFile { get; set; }

        public IQueryable<LogTable> logTable { get; set; }

        [BindProperty]
        public DateTime? ILKTARIH { get; set; } 
        [BindProperty]
        public DateTime? SONTARIH { get; set; }

        public PaginatedList<LogTable> logPagination { get; set; }

        public async Task<IActionResult> OnGetAsync(
            DateTime? ilkTarih, DateTime? sonTarih, int pageIndex = 1)
        {   

            logTable = from l in _context.LogTable select l;

            if(ilkTarih == DateTime.MinValue && sonTarih == DateTime.MinValue) {
                ilkTarih = null;
                sonTarih = null;
            }

            ILKTARIH = ilkTarih;
            SONTARIH = sonTarih;    

            if (ilkTarih != null && sonTarih != null)
            {
                logTable = logTable.Where(s => (s.LogDate >= ilkTarih && s.LogDate <= sonTarih))
                    .OrderByDescending(s => s.LogDate);
            } else 
            {

                logTable = logTable.OrderByDescending(l => l.LogDate);
            }

            //var pageSize = _configuration.GetValue("PageSize", 6);
            var pageSize = 8;

            logPagination = await PaginatedList<LogTable>.CreateAsync(logTable.AsNoTracking(),
                pageIndex , pageSize);

            return Page();
        }

        public async Task<FileContentResult> OnPostDownloadLogFile()
        {
            logFile = from l in _context.LogTable select l;
            logFile = logFile.OrderByDescending(s => s.LogDate);
            string utcNow = System.DateTime.Now.ToString();
            string newLiner = ""; 
            List<string> data = new List<string>();

            data.Add("TARIH" + "," + "EMAIL" + "," + "LOGTURU" + "," + "ACIKLAMA" + Environment.NewLine);

            foreach (var log in logFile)
            {
                var userData = Environment.NewLine + log.LogDate + "," + log.UserEmail +
                "," + log.LogTuru + "," + log.Aciklama + Environment.NewLine;

                for(int i = 0; i < userData.Length-10; i++)
                {
                    newLiner += "-";
                    if(i == userData.Length/2)
                    {
                        newLiner += "************";
                    }
                }

                var newStr = userData + newLiner + Environment.NewLine;

                data.Add(newStr);
                newLiner = "";
            }

            byte[] dataAsBytes = data.SelectMany(s =>
            System.Text.Encoding.UTF8.GetBytes(s + Environment.NewLine)).ToArray();

            return File(dataAsBytes, "text/plain", $"log_file_{utcNow}.txt");
        }

        public void OnPostDeleteLogTable()
        {
             var allLog = from l in _context.LogTable select l;
             _context.LogTable.RemoveRange(allLog);
            _context.SaveChanges();
        }


    }
}
