using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrackingOrder.API.Delivery.DTO.InternalAPIModel.Request;
using TrackingOrder.API.Delivery.DTO.InternalAPIModel.Response;
using TrackingOrder.API.Delivery.INfrastructure.Repository;

namespace TrackingOrder.API.Delivery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderTrackingController : ControllerBase
    {
        private readonly IOrderTrackingRepository _orderTrackingRepository;

        public OrderTrackingController(IOrderTrackingRepository orderTrackingRepository)
        {
            _orderTrackingRepository = orderTrackingRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TrackingOrderResponse>>> GetAllOrderTrackings()
        {
            var orderTrackings = await _orderTrackingRepository.GetAllOrderTrackingsAsync();
            return Ok(orderTrackings);
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<TrackingOrderResponse>> GetOrderTrackingById(Guid orderId)
        {
            var orderIdRequest = new OrderIdRequest { OrderId = orderId };
            var orderTracking = await _orderTrackingRepository.GetOrderTrackingByIdAsync(orderIdRequest);

            if (orderTracking == null)
                return NotFound();

            return Ok(orderTracking);
        }

        //[HttpPost]
        //public async Task<ActionResult> AddOrderTracking(TrackingOrderResponse orderTrackingResponse)
        //{
        //    await _orderTrackingRepository.AddOrderTrackingAsync(orderTrackingResponse);

        //    // مقدار OrderId در TrackingOrderResponse تغییر نمی‌کند
        //    return CreatedAtAction(nameof(GetOrderTrackingById), new { orderId = orderTrackingResponse.OrderId }, orderTrackingResponse);
        //}

        [HttpPut]
        public async Task<ActionResult> UpdateOrderTracking(TrackingOrderResponse orderTrackingResponse)
        {
            await _orderTrackingRepository.UpdateOrderTrackingAsync(orderTrackingResponse);
            return NoContent();
        }

        [HttpDelete("{orderId}")]
        public async Task<ActionResult> DeleteOrderTracking(Guid orderId)
        {
            var orderIdRequest = new OrderIdRequest { OrderId = orderId };
            await _orderTrackingRepository.DeleteOrderTrackingAsync(orderIdRequest);
            return NoContent();
        }
    }
}
