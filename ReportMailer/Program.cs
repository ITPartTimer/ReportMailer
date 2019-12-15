using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using ReportMailer.Models;
using ReportMailer.BLL;

namespace ReportMailer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Hold the command line argument for RptFreq
            List<string> sArgs = new List<string>();
            string rptFreq = string.Empty;

            // Hold messages for the log file
            List<string> logMsgs = new List<string>();

            // Get command line arguments
            // Should be one for RptFreq = D,M,Q,Y
            try
            {
                if (args.Length > 0)
                    rptFreq = args[0].ToString();
                else
                    throw new Exception("No args in command line");
            }
            catch(Exception ex)
            {
                logMsgs.Add("Arg Exception:");
                logMsgs.Add(ex.Message.ToString());
                Logger.Log(logMsgs);

                return;
            }

            /*
            Get all Employees Reports
            */
            ReportsBLL obj = new ReportsBLL();

            List<EmployeesReportsModel> eList = new List<EmployeesReportsModel>();

            try
            {
                eList = obj.Get_Employees_Reports();
            }
            catch (Exception ex)
            {
                logMsgs.Add("Get_Employees_Reports Exception:");
                logMsgs.Add(ex.Message.ToString());
                Logger.Log(logMsgs);

                return;
            }

            /*
            Get all active reports.
            */
            List<ReportsModel> rList = new List<ReportsModel>();

            try
            {
                rList = obj.Get_Reports();
            }
            catch (Exception ex)
            {
                logMsgs.Add("Get_Reports Exception:");
                logMsgs.Add(ex.Message.ToString());
                Logger.Log(logMsgs);

                return;
            }

            // Find Reports where RptFreq = args[0]
            IEnumerable<ReportsModel> rptResults =
                from rpt in rList
                where rpt.freq == rptFreq
                select rpt;

            // Loop through reports
            foreach (var r in rptResults)
            {
                logMsgs.Clear();
                logMsgs.Add("Emailing:");
                logMsgs.Add(r.name + " - " + r.filename + " - " + r.freq);
                logMsgs.Add("Tos:");

                try
                {
                    MailMessage mail = new MailMessage();

                    //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    SmtpClient SmtpServer = new SmtpClient("smtp.office365.com");

                    //mail.From = new MailAddress("nsp.recv@gmail.com");
                    mail.From = new MailAddress("sclemons@calstripsteel.com");
                    mail.Subject = "Report - " + r.name;
                    mail.Body = "Report attached";

                    // Get only employee reports for r.rptID
                    IEnumerable<EmployeesReportsModel> eResults =
                        from e in eList
                        where e.rptID == r.rptID
                        select e;

                    //Build To: line from IEnumerable<EmployeesReportsModel>
                    foreach (var e in eResults)
                    {
                        logMsgs.Add(e.email);
                        mail.To.Add(e.email);
                    }

                    // Add attachment
                    Attachment attach;
                    attach = new Attachment(r.fullpath);
                    mail.Attachments.Add(attach);

                    SmtpServer.Port = 587;
                    //SmtpServer.Credentials = new System.Net.NetworkCredential("nsp.recv@gmail.com", "A8dg2h8q");
                    SmtpServer.Credentials = new System.Net.NetworkCredential("sclemons@calstripsteel.com", "Smet@524");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);

                    Logger.Log(logMsgs);
                }
                catch (Exception ex)
                {
                    logMsgs.Add("Mail Exception:");
                    logMsgs.Add(ex.ToString());
                    Logger.Log(logMsgs);
                }
            } //foreach

            // testing only to stop application so I can read the console
            //Console.WriteLine("Press key to exit");
            //Console.ReadKey();
        }
    }
}
