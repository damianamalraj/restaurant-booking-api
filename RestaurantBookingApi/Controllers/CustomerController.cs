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
      await _customerService.AddCustomerAsync(customerCreateDto);
      return Created();
    }
  }
}