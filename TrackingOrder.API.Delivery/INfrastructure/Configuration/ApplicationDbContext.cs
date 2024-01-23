using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using TrackingOrder.API.Delivery.INfrastructure.Entities;

namespace TrackingOrder.API.Delivery.INfrastructure.Configuration
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        { }

        public DbSet<OrderTracking> OrderTrackings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderTracking>().HasData(
                new OrderTracking { OrderId = Guid.Parse("f7948d66-ae41-4a2b-8a41-a5dea5750243"), Status = "In Progress", UpdateDate = DateTime.Now, Location = "Warehouse", PhoneNumber = "123456789", DeliveryPerson = "John Doe", DeliveryVehicle = "Truck", IsDelivered = false },
                new OrderTracking { OrderId = Guid.Parse("ab3c1a63-fefa-4934-824b-e4b5201cb84a"), Status = "Delivered", UpdateDate = DateTime.Now, Location = "Customer's Address", PhoneNumber = "987654321", DeliveryPerson = "Jane Smith", DeliveryVehicle = "Van", IsDelivered = true }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
    