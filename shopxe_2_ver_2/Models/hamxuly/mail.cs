using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace shopxe_2.Models.hamxuly
{
    public class mail
    {
        public void sendmail(String tomail,String conten) {
            String SendMailFrom = "thichthichich38@gmail.com";
            String SendMailTo = tomail;
            String SendMailSubject = "Thông báo đặt hàng";
            String SendMailBody = conten;
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587);
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage email = new MailMessage();
            // START
            email.From = new MailAddress(SendMailFrom);
            email.To.Add(SendMailTo);
            email.IsBodyHtml = true;
            email.CC.Add(SendMailFrom);
            email.Subject = SendMailSubject;
            email.Body = SendMailBody;
            //END
            SmtpServer.Timeout = 5000;
            SmtpServer.EnableSsl = true;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new NetworkCredential(SendMailFrom, "beyqcxnfyekomutm");
            SmtpServer.Send(email);
        }
    }
}