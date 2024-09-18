using Microsoft.AspNetCore.Mvc;
using RestaurantBookingApi.Models.DTOs.Customer;
using RestaurantBookingApi.Services.IServices;

namespace RestaurantBookingApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CustomerController : ControllerBase
  {
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
      _customerService = customerService;
    }

    [HttpPost]
    [Route("addCustomer")]
    public async Task<IActionResult> AddCustomer(CustomerCreateDTO customerCreateDto)
    {
      await _customerService.AddCustomer(customerCreateDto);
      return Created();
    }

    [HttpGet]
    [Route("getCustomers")]
    public async Task<IActionResult> GetCustomers()
    {
      return Ok(await _customerService.GetCustomers());
    }

    [HttpGet]
    [Route("getCustomer/{customerId}")]
    public async Task<IActionResult> GetCustomer(int customerId)
    {
      return Ok(await _customerService.GetCustomer(customerId));
    }

    [HttpPut]
    [Route("updateCustomer")]
    public async Task<IActionResult> UpdateCustomer(CustomerUpdateDTO customerUpdateDto)
    {
      await _customerService.UpdateCustomer(customerUpdateDto);
      return NoContent();
    }

    [HttpDelete]
    [Route("deleteCustomer/{customerId}")]
    public async Task<IActionResult> DeleteCustomer(int customerId)
    {
      await _customerService.DeleteCustomer(customerId);
      return NoContent();
    }
  }
}