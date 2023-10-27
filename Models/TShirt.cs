using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class TShirt
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
    }
}