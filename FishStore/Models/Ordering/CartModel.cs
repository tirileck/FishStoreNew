using System;
using System.Collections.Generic;
using FishStore.Entities.Ordering;

namespace FishStore.Models.Ordering
{
    public class CartModel
    {
        public IEnumerable<Cart> Carts { get; set; }

        public int Count { get; set; }

        public double Price { get; set; }

        public DateTime ExpectedShippingDate { get; set; } = DateTime.Now.AddDays(14);
    }
}
