using RestaurantBookingApi.Models.DTOs.Customer;

namespace RestaurantBookingApi.Services.IServices
{
  public interface ICustomerService
  {
    Task AddCustomer(CustomerCreateDTO customer);
    Task<Customer> GetCustomer(int customerId);
    Task<IEnumerable<Customer>> GetCustomers();
    Task UpdateCustomer(CustomerUpdateDTO customerUpdateDto);
    Task DeleteCustomer(int customerId);
  }
}