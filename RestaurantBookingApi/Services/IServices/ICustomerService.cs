using RestaurantBookingApi.Models.DTOs.Customer;

namespace RestaurantBookingApi.Services.IServices
{
  public interface ICustomerService
  {
    Task AddCustomerAsync(CustomerCreateDTO customer);
    // Task<Customer> GetCustomer(int customerId);
    // Task<IEnumerable<Customer>> GetCustomers();
    // Task<Customer> UpdateCustomer(Customer customer);
    // Task<Customer> DeleteCustomer(int customerId);
  }
}