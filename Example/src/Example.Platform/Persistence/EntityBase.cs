using System.ComponentModel.DataAnnotations;

namespace Example.Platform.Persistence
{
    public class EntityBase<TKey>
        where TKey : struct
    {
        [Key]
        public TKey Id { get; set; }

        public DateTime CreatedOn { get; }

        public bool IsDeleted { get; set; }

        public EntityBase()
        {
            CreatedOn = DateTime.UtcNow;   
        }
    }
}
