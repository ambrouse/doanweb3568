using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace comon
{
    public class Class1
    {
        public void sendmail(String tomail) {
            String mota = "text mo ta";
            String noidung = "text noi dung";
            String tenmail = ConfigurationManager.AppSettings["tenmail"].ToString();
            String pass = ConfigurationManager.AppSettings["pass"].ToString();
            String host = ConfigurationManager.AppSettings["host"].ToString();
            int port = Int32.Parse(ConfigurationManager.AppSettings["port"].ToString());
            bool ssl = bool.Parse(ConfigurationManager.AppSettings["ssl"].ToString());
            MailMessage thongtin = new MailMessage(new MailAddress(tenmail, "text khong biet"), new MailAddress(tomail));
            thongtin.Subject = mota;
            thongtin.IsBodyHtml = true;
            thongtin.Body = noidung;
            var chucnang = new SmtpClient();
            chucnang.Credentials = new NetworkCredential(tenmail, tomail);
            chucnang.Host = host;
            chucnang.Port = port;
            chucnang.EnableSsl = ssl;
            chucnang.Send(thongtin);
        }
    }
}
