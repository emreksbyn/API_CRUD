using System.ComponentModel.DataAnnotations;

namespace API_CRUD.Models.DTOs
{
    public class CreateCategoryDTO
    {
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [MinLength(3, ErrorMessage = "Min 3 Karakter")]
        [RegularExpression(@"^[a-zA-Z- ]+$", ErrorMessage = "Sadece harf giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Boş bırakılamaz!")]
        [MinLength(3, ErrorMessage = "Min 3 Karakter")]
        public string Description { get; set; }
        public string Slug => Name.ToLower().Replace(' ', '-');
    }
}
