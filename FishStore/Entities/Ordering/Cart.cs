using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FishStore.Entities;
using FishStore.Entities.Accounting;
using FishStore.Entities.Products;

namespace FishStore.Entities.Ordering
{
    public class Cart : BaseObject
    {
        /// <summary>
        /// Получает или задает User
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Получает или задает Id юзера
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Получает или задает Продукт в корзине
        /// </summary>
        public ProductObject Product { get; set; }

        /// <summary>
        /// Получает или задает Id продукта
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Получает или задает Количество продукта в корзине
        /// </summary>
        public int Count { get; set; } = 1;
    }
}
