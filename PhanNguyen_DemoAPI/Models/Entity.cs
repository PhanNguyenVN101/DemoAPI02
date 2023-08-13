using System.ComponentModel.DataAnnotations;

namespace PhanNguyen_DemoAPI.Models
{
    public abstract class Entity
    {
        protected Entity() 
        {
            Id=Guid.NewGuid().ToString();
        }
        [Key]
        public string Id { get; set; }
        public DateTimeOffset ? DeleteDate { get; set; }
    }
}
