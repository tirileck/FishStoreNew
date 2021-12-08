

using System;

namespace FishStore.Entities
{
    public class TypeObject : BaseObject
    {
        public string TypeName { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
