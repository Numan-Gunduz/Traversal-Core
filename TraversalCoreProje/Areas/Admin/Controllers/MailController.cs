using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            MimeMessage mime = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin","traversalrezervasyon@gmail.com");

            mime.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);
            
            mime.To.Add(mailboxAddressTo);
           var bodyBuilder= new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.Body;
            mime.Body=bodyBuilder.ToMessageBody();
            mime.Subject = mailRequest.Subject;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("traversalrezervasyon@gmail.com","nqmdpbmbdgcvabmb");
            smtpClient.Send(mime);
            smtpClient.Disconnect(true);
            TempData["MailResultMessage"] = "Mail basariyla gonderildi.";
            return View();
            //traversalrezervasyon@gmail.com
        }
    }
}
