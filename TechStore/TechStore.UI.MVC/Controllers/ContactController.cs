using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TechStore.UI.MVC.Models;
using MailKit.Net.Smtp;

namespace TechStore.UI.MVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly IConfiguration _config;

        public ContactController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactViewModel cvm)
        {
            if (!ModelState.IsValid)
            {

                ViewBag.Scroll = true;
                ViewBag.ErrorMessage = "Required Items are missing from the form!";
                return View(cvm);
            }
            ViewBag.Submit = true;
            var mm = new MimeMessage();

            string message = $"You have received a new email from your site's contact form!<br/>" +
                $"Sender: {cvm.Name}<br/>Email: {cvm.Email}<br/>Subject: {cvm.Subject}<br/>" +
                $"Message: {cvm.Message}";

            mm.From.Add(new MailboxAddress("Sender", _config.GetValue<string>("Credentials:Email:User")));


            mm.To.Add(new MailboxAddress("Personal", _config.GetValue<string>("Credentials:Email:Recipient")));

            mm.Subject = cvm.Subject;

            mm.Body = new TextPart("HTML") { Text = message };

            mm.Priority = MessagePriority.Urgent;


            mm.ReplyTo.Add(new MailboxAddress("User", cvm.Email));

            using (var client = new SmtpClient())
            {
                client.Connect(_config.GetValue<string>("Credentials:Email:Client"));

                client.Authenticate(_config.GetValue<string>("Credentials:Email:User"), _config.GetValue<string>("Credentials:Email:Password"));

                try
                {
                    client.Send(mm);
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = $"There was an error processing your request.  Please try again later.<br/> Error Message: {ex.StackTrace}";
                    return View(cvm);
                }
            }
            ModelState.Clear();
            return View("ContactConfirmation", cvm);
        }
    }
}
