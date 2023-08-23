using Microsoft.AspNetCore.Identity.UI.Services;

namespace SwapnilAsp.Utility
{
	public class EmailSender : IEmailSender
	{
		Task IEmailSender.SendEmailAsync(string email, string subject, string htmlMessage)
		{
			// logic to sendemail;
			return Task.CompletedTask;
		}
	}
}
