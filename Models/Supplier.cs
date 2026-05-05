using System.ComponentModel.DataAnnotations;

namespace ptpmql.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Tên không được để trống")]
        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }
    }
}