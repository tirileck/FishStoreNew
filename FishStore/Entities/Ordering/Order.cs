using System;
using System.Collections.Generic;
using FishStore.Entities.Products;
using FishStore.Entities.Accounting;
using FishStore.Entities.Ordering.OrderDicts;

namespace FishStore.Entities.Ordering
{
    public class Order : TypeObject
    {
        public Order()
        {
            TypeName = nameof(Order);
            Products = new List<ProductObject>();
        }

        public ICollection<ProductObject> Products { get; set; }

        public User User { get; set; }

        public int? UserId { get; set; }

        public string Adress { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public int? OrderStatusId { get; set; } = 102;

        public double? Cost { get; set; }
    }
}
