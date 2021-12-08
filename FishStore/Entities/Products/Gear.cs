using FishStore.Entities.Products.ProductDicts;

namespace FishStore.Entities.Products
{
    /// <summary>
    /// Класс - снасти
    /// </summary>
    public class Gear : ProductObject
    {
        public Gear()
        {
            TypeName = nameof(Gear);
        }
        public virtual TypeOfGear TypeOfGear { get; set; }
        public int TypeOfGearID { get; set; }
    }
}
