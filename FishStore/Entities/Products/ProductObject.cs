namespace FishStore.Entities.Products
{
    public class ProductObject : TypeObject
    {
        public ProductObject()
        {
            TypeName = nameof(ProductObject);
        }
        /// <summary>
        /// Gets or sets Имя продуктв
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets Ссылка на фото продукта
        /// </summary>
        public string PhotoLink { get; set; }

        /// <summary>
        /// Gets or Sets Цена продукта
        /// </summary>
        public double Cost { get; set; }

        /// <summary>
        /// Gets or Sets Размер продуктв
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// Gets or Sets Вес продуктв
        /// </summary>
        public double? Weight { get; set; }
    }
}
