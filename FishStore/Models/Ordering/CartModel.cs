using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FishStore.Entities.Ordering;

namespace FishStore.Models.Ordering
{
    public class CartModel
    {
        public IEnumerable<Cart> Carts { get; set; }

        public int Count { get; set; }

        public double Price { get; set; }

        public string Adress { get; set; }

        public DateTime ExpectedShippingDate { get; set; } = DateTime.Now.AddDays(14);
    }
}
