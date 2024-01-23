using System.ComponentModel.DataAnnotations;

namespace TrackingOrder.API.Delivery.INfrastructure.Entities
{
    public class OrderTracking
    {
        [Key]
        public Guid OrderId { get; set; }
        public string Status { get; set; }
        public DateTime UpdateDate { get; set; }    
        public string Location { get; set; }    
        public string PhoneNumber { get; set; }    
        public string DeliveryPerson { get; set; } 
        public string DeliveryVehicle { get; set; } 
        public bool IsDelivered { get; set; } 
    }
}
