namespace RestaurantBookingApi.Services.IServices
{
  public interface IEmailService
  {
    Task<bool> SendEmailAsync(string email, string subject, string htmlContent);
  }
}
