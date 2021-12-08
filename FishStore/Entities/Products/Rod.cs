using FishStore.Entities.Products.ProductDicts;

namespace FishStore.Entities.Products
{
    /// <summary>
    /// Класс удочек
    /// </summary>
    public class Rod : ProductObject
    {
        public virtual TypeOfRod TypeOfRod { get; set; }
        public int TypeOfRodID { get; set; }
    }
}
