using System.ComponentModel.DataAnnotations;

namespace API_CRUD.Models.DTOs
{
    public class AuthenticationDTO
    {
        [Required(ErrorMessage = "Boş bırakılamaz.")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Boş bırakılamaz.")]
        public string Password { get; set; }
    }
}
