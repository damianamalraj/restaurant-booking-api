using System.Net.Mime;
using Azure;
using Azure.Communication.Email;
using RestaurantBookingApi.Services.IServices;

namespace RestaurantBookingApi.Services.EmailService
{
  public class EmailService : IEmailService
  {
    private readonly EmailClient _emailClient;

    public EmailService(EmailClient emailClient)
    {
      _emailClient = emailClient;
    }

    public async Task<bool> SendEmailAsync(string email, string subject, string htmlContent)
    {
      try
      {
        var emailMessage = new EmailMessage(
        senderAddress: "DoNotReply@f1ca974d-ab06-4206-b5e9-9e1e47cf92d4.azurecomm.net",
        content: new EmailContent(subject)
        {
          Html = htmlContent
        },
        recipients: new EmailRecipients(new List<EmailAddress>
        {
          new EmailAddress(email)
        })
      );

        var response = await _emailClient.SendAsync(WaitUntil.Completed, emailMessage);

        return response.HasCompleted;
      }
      catch (Exception)
      {

        return false;
      }
    }

  }
}
