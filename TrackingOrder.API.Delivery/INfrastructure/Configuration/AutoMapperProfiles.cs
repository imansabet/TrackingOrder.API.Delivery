using AutoMapper;
using TrackingOrder.API.Delivery.DTO.InternalAPIModel.Request;
using TrackingOrder.API.Delivery.DTO.InternalAPIModel.Response;
using TrackingOrder.API.Delivery.INfrastructure.Entities;

namespace TrackingOrder.API.Delivery.INfrastructure.Configuration
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<OrderTracking, OrderIdRequest>().ReverseMap();
            CreateMap<OrderTracking, TrackingOrderResponse>().ReverseMap()
                .ForMember(dest => dest.OrderId, opt => opt.Ignore());

        }
    }
}
