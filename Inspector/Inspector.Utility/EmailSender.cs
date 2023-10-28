using System.Net;
using System.Net.Mail;

namespace Inspector.Utility
{
	public class EmailSender : IEmailSender
	{
		public Task SendEmailAsync(string email, string? subject, string? htmlMessage, int? orgID)
		{
			var mail = "inspectorapp2023@gmail.com";
			subject = "Response from inspector.web";
			if (orgID != null)
			{
				htmlMessage = "You have received a new task from your company!" +
				"\r\nGo check the web site to see more." +
				"\r\n\r\nRegards," +
				"\r\nThe Inspector team";
			}
			else
			{
				htmlMessage = "You have received a response for your complaint!" +
				"\r\nGo check the web site to see more." +
				"\r\n\r\nRegards," +
				"\r\nThe Inspector team";
			}
			

			var client = new SmtpClient("smtp.outlook.com", 587)
			{
				EnableSsl = true,
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential(mail, "Inspector123!")
			};

			return client.SendMailAsync(
				new MailMessage(from: mail,
								to: email,
								subject,
								htmlMessage));
		}
	}
}
