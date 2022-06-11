using System.ComponentModel.DataAnnotations;

namespace API1
{
    public class Stores
    {
        [Key]
        public int StoreId { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Location { get; set; } = String.Empty;
        public ICollection<clothes> Clothes { get; set; }

    }
}
