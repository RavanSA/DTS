using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using WebApp1.Models;

namespace WebApp1.Pages.Rapor
{
    [Authorize]
    public class RaporModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public RaporModel(IConfiguration configuration)
        {
            _configuration = configuration;
            con.ConnectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();
       

        public List<Models.Rapor> rapor = new List<Models.Rapor>();

        public DateTime  ilkTarih{get; set;}

        public DateTime sonTarih { get; set; }

        public bool lehte { get; set; }

        public FileContentResult excel_file { get; set; }


        public void OnGet(DateTime ilkTarih, DateTime sonTarih, bool? lehte)
        {

            if (lehte != null) {

                //var lehteInt = lehte ? 1 : 0;

                if (!(lehte == null
                    || ilkTarih == DateTime.MinValue
                    || sonTarih == DateTime.MinValue))
                {
                  

                            con.Open();
                            com.Connection = con;
                            com.CommandText = "SELECT * FROM func_DonemlikRapor(@ilkTarih,@sonTarih,@lehteInt)";
                            com.Parameters.Add("@ilkTarih", SqlDbType.DateTime).Value = ilkTarih;
                            com.Parameters.Add("@sonTarih", SqlDbType.DateTime).Value = sonTarih;
                            com.Parameters.Add("@lehteInt", SqlDbType.Bit).Value = lehte;

                            dr = com.ExecuteReader();



                            while (dr.Read())
                            {
                                rapor.Add(new Models.Rapor()
                                {
                                    SIRA_NO = (int)dr["SIRA_NO"],
                                    CSS_CLASS = dr["CSS_CLASS"].ToString(),
                                    TANIM = dr["TANIM"].ToString(),
                                    SAYI = (dr["SAYI"] as int?).GetValueOrDefault(),
                                    DEGER = (dr["DEGER"] as decimal?).GetValueOrDefault()
                                });
                            }
                }
            }
        }


        public FileContentResult OnPostDownloadCSV()
        {
            var ilkTarih1 = Request.Form["ilkTarih"];
            var sonTarih1 = Request.Form["sonTarih"];
            var lehte = Request.Form["lehte"];
            DateTime ilkTarihDate = DateTime.Parse(ilkTarih1);
            DateTime sonTarihDate = DateTime.Parse(sonTarih1);

            var lehteInt = lehte == "false" ? 0 : 1;
            

            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM func_DonemlikRapor(@ilkTarih,@sonTarih,@lehteInt)";
            com.Parameters.Add("@ilkTarih", SqlDbType.DateTime).Value = ilkTarihDate;
            com.Parameters.Add("@sonTarih", SqlDbType.DateTime).Value = sonTarihDate;
            com.Parameters.Add("@lehteInt", SqlDbType.Bit).Value = lehteInt;

            dr = com.ExecuteReader();

            while (dr.Read())
            {
                rapor.Add(new Models.Rapor()
                {
                    SIRA_NO = (int)dr["SIRA_NO"],
                    CSS_CLASS = dr["CSS_CLASS"].ToString(),
                    TANIM = dr["TANIM"].ToString(),
                    SAYI = (dr["SAYI"] as int?).GetValueOrDefault(),
                    DEGER = (dr["DEGER"] as decimal?).GetValueOrDefault()
                });

            }

            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[5]
            {
                            new DataColumn("SIRA_NO"),
                            new DataColumn("CSS_CLASS"),
                            new DataColumn("TANIM"),
                            new DataColumn("SAYI"),
                            new DataColumn("DEGER")
            });

            foreach (var i in rapor)
            {
                dt.Rows.Add(
                    i.SIRA_NO,
                    i.CSS_CLASS,
                    i.TANIM,
                    i.SAYI,
                    i.DEGER
                    );
            }


            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    con.Close();
                    excel_file = File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "rapor_donemlik.xlsx");
                    return excel_file;
                }
            }

            }

    }
}



