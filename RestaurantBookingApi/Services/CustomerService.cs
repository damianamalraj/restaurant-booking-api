using RestaurantBookingApi.Data.Repositories.IRepositories;
using RestaurantBookingApi.Models.DTOs.Customer;
using RestaurantBookingApi.Services.IServices;

namespace RestaurantBookingApi.Services
{
  public class CustomerService : ICustomerService
  {
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
      _customerRepository = customerRepository;
    }

    public async Task AddCustomerAsync(CustomerCreateDTO customer)
    {
      await _customerRepository.AddCustomerAsync(new Customer
      {
        Name = customer.Name,
        ContactInfo = customer.ContactInfo
      });
    }
  }
}