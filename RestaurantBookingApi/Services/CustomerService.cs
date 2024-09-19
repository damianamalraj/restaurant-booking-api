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

    public async Task AddCustomer(CustomerCreateDTO customer)
    {
      await _customerRepository.AddCustomerAsync(new Customer
      {
        Name = customer.Name,
        ContactInfo = customer.ContactInfo
      });
    }

    public async Task<Customer> GetCustomer(int customerId)
    {
      return await _customerRepository.GetCustomerAsync(customerId);
    }

    public async Task<IEnumerable<Customer>> GetCustomers()
    {
      return await _customerRepository.GetCustomersAsync();
    }

    public async Task UpdateCustomer(int customerId, CustomerUpdateDTO customerUpdateDto)
    {
      var customer = await _customerRepository.GetCustomerAsync(customerId);
      customer.Name = customerUpdateDto.Name;
      customer.ContactInfo = customerUpdateDto.ContactInfo;

      await _customerRepository.UpdateCustomerAsync(customer);
    }

    public async Task DeleteCustomer(int customerId)
    {
      await _customerRepository.DeleteCustomerAsync(customerId);
    }
  }
}