using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using MailKit.Net.Smtp;
using MimeKit;

namespace North.ClassLib.ConvertPages
{
    public class MailC
    {
        string AdminNameEX = "Bişeyler A.Ş";
        string AdminMailEX = "smerch-nurlan@mail.ru";
        string AdminPasswordEX = ":P";
        string smtpMailEX = "smtp.mail.ru";
        int portEX = 465;


        public bool sendMail(string invocePath,  string UserName, string UserMail,string mailSubject
            , string mailContainer)
        {
            //string UserNameEX = "User";
            //string UserMailEX = "nurlan.goyjali@gmail.com";
            //string mailSubjectEX = "Mail konusu";// konu
            //string mailContainerEX = "do u know this is my first mail";


            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress(AdminNameEX, AdminMailEX);
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress(UserName, UserMail);
            message.To.Add(to);

            message.Subject = mailSubject;

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = mailContainer;
            bodyBuilder.TextBody = " ";

            bodyBuilder.Attachments.Add(invocePath);

            message.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();
            client.Connect(smtpMailEX, portEX, true);
            client.Authenticate(AdminMailEX, AdminPasswordEX);

            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
            System.IO.File.Delete("\\Users\\90545\\source\\repos\\North\\North.UserUI\\result.pdf");
            return true;

           
        }



    }
}
