using System.ComponentModel.DataAnnotations;

namespace CRUDify_API.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name field is required.")]
        public string ?Name { get; set; }
        public int ?Age { get; set; }
        public string ?Color { get; set; }
    }

}
