using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportMailer.Models
{
    public class ReportsModel
    {
        public int rptID { get; set; }
        public string name { get; set; }
        public string rootpath { get; set; }
        public string filename { get; set; }
        public string fullpath { get; set; }
        public string freq { get; set; }
    }

    public class EmployeesReportsModel
    {
        public int rptID { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string rootpath { get; set; }
        public string filename { get; set; }
        public string fullpath { get; set; }
        public string freq { get; set; }
    }

    public class LogModel
    {
        public string msg { get; set; }
    }

    public class BookingsModel
    {
        public int workDy { get; set; }
        public int prodDt { get; set; }
        public int swDly { get; set; }
        public int msDly { get; set; }
        public int swAve { get; set; }
        public int msAve { get; set; }
    }
}
