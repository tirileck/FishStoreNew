using FishStore.Entities.Products;

namespace FishStore.Entities.Ordering
{
    public class OrderItem : BaseObject
    {
        /// <summary>
        /// Получает или задает Продукт в заказе
        /// </summary>
        public ProductObject Product { get; set; }

        /// <summary>
        /// Получает или задает Id продукта
        /// </summary>
        public int? ProductId { get; set; }

        /// <summary>
        /// Получает или задает Количество продукта в заказе
        /// </summary>
        public int Count { get; set; } = 1;

        /// <summary>
        /// Получает или задает заказ
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// Получает или задает ID заказа
        /// </summary>
        public int? OrderId { get; set; }
    }
}
