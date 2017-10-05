using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CTM.WFServices.Email
{
    public interface IMessageService
    {
        /// <summary>
        /// Send an EMail using String
        /// </summary>
        /// <param name="messageBody">Message Body String</param>
        /// <param name="varsBindingReplacmentsList">Key / Value Variables Binding List</param>
        /// <param name="subject">EMail Subject</param>
        /// <param name="from">From</param>
        /// <param name="fromDisplayName">Sender Dispaly Name</param>
        /// <param name="to">To</param>
        /// <param name="cc">CC</param>
        /// <param name="bcc">BCC</param>
        /// <param name="priority">EMail Priority</param>
        void SendEmail(
            string messageBody,
            System.Collections.Specialized.ListDictionary varsBindingReplacmentsList,
            string subject,
            string from,
            string fromDisplayName,
            string to,
            string cc,
            string bcc,
            MailPriority priority = MailPriority.Normal);

        /// <summary>
        ///  Send an EMail using HTML file Template
        /// </summary>
        /// <param name="htmlFileTemplatePath">Html File Template Path</param>
        /// <param name="varsBindingReplacmentsList">Key / Value Variables Binding List</param>
        /// <param name="subject">EMail Subject</param>
        /// <param name="from">From</param>
        /// <param name="fromDisplayName">Sender Dispaly Name</param>
        /// <param name="to">To</param>
        /// <param name="cc">CC</param>
        /// <param name="bcc">BCC</param>
        /// <param name="priority">EMail Priority</param>
        void SendEmailUsingHTMLFileTemplate(
            string htmlFileTemplatePath,
            System.Collections.Specialized.ListDictionary varsBindingReplacmentsList,
            string subject,
            string from,
            string fromDisplayName,
            string to,
            string cc,
            string bcc,
            MailPriority priority = MailPriority.Normal);
    }
}
