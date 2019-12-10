using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class CustomersModel
    {
        public int Cid { get; set; }
        [Required(ErrorMessage = "Please provide valid Name for Customer!")]
        public string Name { get; set; }
        [Required]
        public string Telephone { get; set; }
        public string Email { get; set; }
    }
}
