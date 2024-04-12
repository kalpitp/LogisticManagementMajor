using LogisticsManagement.Service.Services.IServices;
using LogisticsManagement.WebAPI.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LogisticsManagement.WebAPI.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IDriverService _driverService;
        private readonly ICustomerService _customerService;

        public OrderController(IDriverService driverService, ICustomerService customerService)
        {
            _driverService = driverService;
            _customerService = customerService;
        }

        [HttpGet("order-details/{orderId:int}")]
        //[Authorize(Roles = "Customer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetOrderDetails(int orderId)
        {
            try
            {
                if (orderId <= 0)
                {
                    return BadRequest(ApiResponseHelper.Response(false, HttpStatusCode.BadRequest, null, "Please enter valid id"));
                }

                var orderDetails = await _customerService.ViewOrderDetails(orderId);

                if (orderDetails == null)
                {
                    return NotFound(ApiResponseHelper.Response(false, HttpStatusCode.NotFound, null, "Order with given id not found"));
                }

                return Ok(ApiResponseHelper.Response(true, HttpStatusCode.OK, orderDetails, string.Empty));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApiResponseHelper.Response(false, HttpStatusCode.InternalServerError, null, ex.Message));
            }
        }
    }
}
