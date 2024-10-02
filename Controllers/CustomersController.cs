using Microsoft.AspNetCore.Mvc;
using RestaurantBookingApi.Models.DTOs.Customer;
using RestaurantBookingApi.Services.IServices;

namespace RestaurantBookingApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CustomersController : ControllerBase
  {
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
      _customerService = customerService;
    }

    [HttpPost]
    public async Task<IActionResult> AddCustomer(CustomerCreateDTO customerCreateDto)
    {
      await _customerService.AddCustomer(customerCreateDto);
      return Created();
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomers()
    {
      return Ok(await _customerService.GetCustomers());
    }

    [HttpGet]
    [Route("{customerId}")]
    public async Task<IActionResult> GetCustomer(int customerId)
    {
      return Ok(await _customerService.GetCustomer(customerId));
    }

    [HttpPut]
    [Route("{customerId}")]
    public async Task<IActionResult> UpdateCustomer(int customerId, CustomerUpdateDTO customerUpdateDto)
    {
      await _customerService.UpdateCustomer(customerId, customerUpdateDto);
      return NoContent();
    }

    [HttpDelete]
    [Route("{customerId}")]
    public async Task<IActionResult> DeleteCustomer(int customerId)
    {
      await _customerService.DeleteCustomer(customerId);
      return NoContent();
    }
  }
}