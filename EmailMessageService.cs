using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;


namespace CTM.WFServices.Email
{
    public class EmailMessageService : IMessageService
    {
        public void SendEmail(string messageBody, ListDictionary varsBindingReplacmentsList, string subject, string from, string fromDisplayName, string to, string cc, string bcc, MailPriority priority = MailPriority.Normal)
        {
            SendEmail(messageBody, false, varsBindingReplacmentsList, subject, from, fromDisplayName, to, cc, bcc, priority);
        }

        public void SendEmailUsingHTMLFileTemplate(string htmlFileTemplatePath, ListDictionary varsBindingReplacmentsList, string subject, string from, string fromDisplayName, string to, string cc, string bcc, MailPriority priority = MailPriority.Normal)
        {
            SendEmail(htmlFileTemplatePath, true, varsBindingReplacmentsList, subject, from, fromDisplayName, to, cc, bcc, priority);
        }

        private void SendEmail(string bodyOrFilePath, bool isHtmlFile, ListDictionary replacmentsList, string subject, string from, string fromDisplayName, string to, string cc, string bcc, MailPriority priority)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.BodyEncoding = Encoding.Unicode;
            mailMessage.IsBodyHtml = true;
            mailMessage.Priority = priority;


            mailMessage.From = new MailAddress(from, fromDisplayName, Encoding.Unicode);
            mailMessage.To.Add(to);// Email Collection Separated with Comma ,           

            if (!string.IsNullOrWhiteSpace(cc))
                mailMessage.CC.Add(cc);//Email Collection  Separated with Comma ,            
            if (!string.IsNullOrWhiteSpace(bcc))
                mailMessage.Bcc.Add(bcc);//Email Collection  Separated with Comma ,                           

            mailMessage.Subject = subject;

            #region Other
            //mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions
            //mailMessage.Attachments
            //mailMessage.BodyTransferEncoding 
            #endregion

            if (isHtmlFile)
                bodyOrFilePath = File.ReadAllText(bodyOrFilePath);

            foreach (DictionaryEntry item in replacmentsList)
            {
                bodyOrFilePath = bodyOrFilePath.Replace(item.Key.ToString(), item.Value.ToString());
            }

            mailMessage.Body = bodyOrFilePath;

            SmtpClient client = new SmtpClient
            {
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Host = "mySMTP.host",
                Port = 587,
                Credentials = new NetworkCredential("info@mysystem.com", "222")
            };

            client.Send(mailMessage);
        }
    }
}

#region HowToUse

//[Route("Test")]
//[HttpGet]
//public string Test()
//{
//    //-------------------
//    var templatePath = $@"{Directory.GetCurrentDirectory()}\Contents\Emails\NewTask.html";
//    System.Collections.Specialized.ListDictionary replacements = new System.Collections.Specialized.ListDictionary();
//    replacements.Add("<%CreatedBy%>", "naadydev@gmail.com");
//    replacements.Add("<%AssignedTo%>", "nadydev@outlook.com");
//    replacements.Add("<%ReqDate%>", DateTime.Now.ToString("MMM ddd dd/MM/yyy hh:mm:ss"));
//    replacements.Add("<%TaskUrl%>", $"http://Mysystem/CTM/Tasks/{taskId}");
//    //-------------------
//    _messageService.SendEmail("My Message Body", replacements, "New Task", "info@mysystem.com", "My System", "naadydev@gmail.com", "", "");
//    _messageService.SendEmailUsingHTMLFileTemplate(templatePath, replacements, "New Task", "info@mysystem.com", "My System", "naadydev@gmail.com", "", "");

//    return "ok";
//}
#endregion
