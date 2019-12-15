using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportMailer.DAL;
using ReportMailer.Models;

namespace ReportMailer.BLL
{
    [DataObject(true)]
    public class ReportsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ReportsModel> Get_Reports()
        {
            ReportsDAL obj = new ReportsDAL();

            List<ReportsModel> lst = new List<ReportsModel>();
          
            lst = obj.LKU_Reports_Active();         

            return lst;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<EmployeesReportsModel> Get_Employees_Reports()
        {
            ReportsDAL obj = new ReportsDAL();

            List<EmployeesReportsModel> lst = new List<EmployeesReportsModel>();
         
            lst = obj.LKU_Employees_Reports_Active();
           
            return lst;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<BookingsModel> Get_Bookings_MTY()
        {
            ReportsDAL obj = new ReportsDAL();

            List<BookingsModel> lst = new List<BookingsModel>();

            lst = obj.LKU_Bookings_MTY();

            return lst;
        }
    }
}
