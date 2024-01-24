using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TrackingOrder.API.Delivery.DTO.InternalAPIModel.Request;
using TrackingOrder.API.Delivery.DTO.InternalAPIModel.Response;
using TrackingOrder.API.Delivery.INfrastructure.Configuration;
using TrackingOrder.API.Delivery.INfrastructure.Entities;

namespace TrackingOrder.API.Delivery.INfrastructure.Repository
{
    public class OrderTrackingRepository : IOrderTrackingRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderTrackingRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<TrackingOrderResponse>> GetAllOrderTrackingsAsync()
        {
            var orderTrackings = await _dbContext.OrderTrackings.ToListAsync();
            return _mapper.Map<List<TrackingOrderResponse>>(orderTrackings);
        }

        public async Task<TrackingOrderResponse> GetOrderTrackingByIdAsync(OrderIdRequest orderIdRequest)
        {
            var orderTracking = await _dbContext.OrderTrackings
                .FirstOrDefaultAsync(x => x.OrderId == orderIdRequest.OrderId);

            return _mapper.Map<TrackingOrderResponse>(orderTracking);
        }

        public async Task AddOrderTrackingAsync(TrackingOrderResponse orderTrackingResponse)
        {
            var orderTrackingEntity = _mapper.Map<OrderTracking>(orderTrackingResponse);
            _dbContext.OrderTrackings.Add(orderTrackingEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateOrderTrackingAsync(TrackingOrderResponse trackingOrderResponse)
        {
            var orderTrackingEntity = await _dbContext.OrderTrackings
                .FirstOrDefaultAsync(x => x.IsDelivered == trackingOrderResponse.IsDelivered);

            if (orderTrackingEntity != null)
            {
                _mapper.Map(trackingOrderResponse, orderTrackingEntity);

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteOrderTrackingAsync(OrderIdRequest orderIdRequest)
        {
            var orderTrackingEntity = await _dbContext.OrderTrackings
                .FirstOrDefaultAsync(x => x.OrderId == orderIdRequest.OrderId);

            if (orderTrackingEntity != null)
            {
                _dbContext.OrderTrackings.Remove(orderTrackingEntity);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
