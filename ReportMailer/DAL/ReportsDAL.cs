using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportMailer.Models;

namespace ReportMailer.DAL
{
    [DataObject(true)]
    public class ReportsDAL : SQLHelpers
    {
        // ---------------------------------------------------
        // Return all active reports
        // ---------------------------------------------------
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ReportsModel> LKU_Reports_Active()
        {
            List<ReportsModel> lst = new List<ReportsModel>();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader rdr = default(SqlDataReader);

            SqlConnection conn = new SqlConnection(STRATIXDataConnString);

            using (conn)
            {
                conn.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RPT_LKU_proc_Reports_Active";
                cmd.Connection = conn;

                rdr = cmd.ExecuteReader();

                using (rdr)
                {
                    while (rdr.Read())
                    {
                        ReportsModel r = new ReportsModel();

                        r.rptID = (int)rdr["RptID"];
                        r.name = (string)rdr["RptName"];
                        r.rootpath = (string)rdr["RptRootPath"];
                        r.filename = (string)rdr["RptFileName"];
                        r.fullpath = (string)rdr["RptFullPath"];
                        r.freq = (string)rdr["RptFreq"];

                        lst.Add(r);
                    }
                }
            }
            
            return lst;
        }

        // ---------------------------------------------------
        // Return all active employee reports with detail
        // ---------------------------------------------------
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<EmployeesReportsModel> LKU_Employees_Reports_Active()
        {
            List<EmployeesReportsModel> lst = new List<EmployeesReportsModel>();
           
            SqlCommand cmd = new SqlCommand();
            SqlDataReader rdr = default(SqlDataReader);
           
            SqlConnection conn = new SqlConnection(STRATIXDataConnString);             

            using (conn)
            {
                conn.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RPT_LKU_proc_Employees_Reports_Active";
                cmd.Connection = conn;

                rdr = cmd.ExecuteReader();

                using (rdr)
                {
                    while (rdr.Read())
                    {
                        EmployeesReportsModel r = new EmployeesReportsModel();

                        r.rptID = (int)rdr["RptID"];
                        r.email = (string)rdr["EmpEmail"];
                        r.name = (string)rdr["RptName"];
                        r.rootpath = (string)rdr["RptRootPath"];
                        r.filename = (string)rdr["RptFileName"];
                        r.fullpath = (string)rdr["RptFullPath"];
                        r.freq = (string)rdr["RptFreq"];

                        lst.Add(r);
                    }
                }
            }           
            return lst;
        }

        // ---------------------------------------------------
        // Return Bookings MTY
        // ---------------------------------------------------
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<BookingsModel> LKU_Bookings_MTY()
        {
            List<BookingsModel> lst = new List<BookingsModel>();

            SqlCommand cmd = new SqlCommand();
            SqlDataReader rdr = default(SqlDataReader);

            SqlConnection conn = new SqlConnection(STRATIXDataConnString);

            using (conn)
            {
                conn.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SCORE_LKU_proc_Bookings_MTY";
                cmd.Connection = conn;

                rdr = cmd.ExecuteReader();

                using (rdr)
                {
                    while (rdr.Read())
                    {
                        BookingsModel r = new BookingsModel();

                        r.workDy = (int)rdr["WORK_DY"];
                        r.prodDt = (int)rdr["WORK_DY"];
                        r.swDly = (int)rdr["SW_DLY"];
                        r.msDly = (int)rdr["MS_DLY"];
                        r.swAve = (int)rdr["SW_AVE"];
                        r.msAve = (int)rdr["MS_AVE"];

                        lst.Add(r);
                    }
                }
            }
            return lst;
        }
    }
}
