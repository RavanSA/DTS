using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{
    public class LogTable
    {
        [Key]
        public Guid LogId { get; set; }

        public string UserId { get; set; }

        public string UserEmail { get; set; }

        public DateTime LogDate { get; set; }

        public string LogTuru { get; set; }

        public string Aciklama { get; set; }

    }
}
