using TrackingOrder.API.Delivery.DTO.InternalAPIModel.Request;
using TrackingOrder.API.Delivery.DTO.InternalAPIModel.Response;

namespace TrackingOrder.API.Delivery.INfrastructure.Repository
{
    public interface IOrderTrackingRepository
    {
        Task<List<TrackingOrderResponse>> GetAllOrderTrackingsAsync();
        Task<TrackingOrderResponse> GetOrderTrackingByIdAsync(OrderIdRequest orderIdRequest);
        Task AddOrderTrackingAsync(TrackingOrderResponse orderTrackingResponse);
        Task UpdateOrderTrackingAsync(TrackingOrderResponse orderTrackingResponse);
        Task DeleteOrderTrackingAsync(OrderIdRequest orderIdRequest);
    }
}
