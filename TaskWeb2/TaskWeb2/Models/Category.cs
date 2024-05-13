using System.ComponentModel.DataAnnotations;

namespace TaskWeb2.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Duzgun doldur!!!!!!!!")]
        public string Name { get; set; }

        public List<Product>? Products { get; set; }
    }
}
