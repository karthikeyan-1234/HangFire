using Hangfire;
using HangFire.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HangFire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangFireController : ControllerBase
    {
        MailObj obj = new MailObj();

        [HttpPost("Welcome")]
        public IActionResult Welcome(string username)
        {
            var jobId = BackgroundJob.Enqueue(() => obj.SendWelcomeMail(username));
            return Ok($"JobId : {jobId} Completed. Welcome mail sent");
        }

        [HttpPost("Delayed")]
        public IActionResult Delayed(string username)
        {
            var jobId = BackgroundJob.Schedule(() => obj.SendDelayedWelcomeMail(username),TimeSpan.FromSeconds(30));
            return Ok($"JobId : {jobId} Scheduled. Welcome mail will be sent after 30 secs");
        }

        [HttpPost("Invoice")]
        public IActionResult Invoice(string username)
        {
            RecurringJob.AddOrUpdate(() => obj.SendInvoiceMail(username), Cron.Minutely);
            return Ok($"Recurring job send Invoice mail scheduled for {username}");
        }

        [HttpPost("UnSubscribe")]
        public IActionResult UnSubscribe(string username)
        {
            var jobId = BackgroundJob.Enqueue(() => obj.UnSubscribeUser(username));
            BackgroundJob.ContinueJobWith(jobId, () => Console.WriteLine($"Job Id {jobId}, Confirmation mail will be sent"));
            return Ok("UnSubscribed");
        }
    }
}
