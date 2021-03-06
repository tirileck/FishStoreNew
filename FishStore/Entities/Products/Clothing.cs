    using FishStore.Entities.Products.ProductDicts;

namespace FishStore.Entities.Products
{
    /// <summary>
    /// Класс одежды
    /// </summary>
    public class Clothing : ProductObject
    {
        public Clothing()
        {
            TypeName = nameof(Clothing);
        }
        public virtual TypeOfClothing TypeOfClothing { get; set; }
        public int TypeOfClothingID { get; set; }
    }
}
