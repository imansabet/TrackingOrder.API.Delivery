namespace TrackingOrder.API.Delivery.DTO.InternalAPIModel.Response
{
    public class TrackingOrderResponse
    {
        public string Status { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string DeliveryPerson { get; set; }
        public string DeliveryVehicle { get; set; }
        public bool IsDelivered { get; set; }
    }
}
