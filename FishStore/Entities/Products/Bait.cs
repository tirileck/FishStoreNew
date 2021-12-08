using FishStore.Entities.Products.ProductDicts;

namespace FishStore.Entities.Products
{
    /// <summary>
    /// Класс наживки
    /// </summary>
    public class Bait : ProductObject
    {
        public Bait()
        {
            TypeName = nameof(Bait);
        }
        public virtual TypeOfBait TypeOfBait { get; set; }
        public int TypeOfBaitID { get; set; }
    }
}
