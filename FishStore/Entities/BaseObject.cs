using System.ComponentModel.DataAnnotations;

namespace FishStore.Entities
{
    public class BaseObject
    {
        [Key]
        public int ID { get; set; }
    }
}
