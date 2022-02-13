using API_CRUD.Models.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_CRUD.Models.DTOs
{
    public class UpdateCategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Boş bırakılamaz")]
        [MinLength(3, ErrorMessage = "Min 3 Karakter")]
        [RegularExpression(@"^[a-zA-Z- ]+$", ErrorMessage = "Sadece harf giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Boş bırakılamaz")]
        [MinLength(3, ErrorMessage = "Min 3 Karakter")]
        public string Description { get; set; }
        public string Slug => Name.ToLower().Replace(' ', '-');
        public DateTime UpdateDate => DateTime.Now;

        [NotMapped]
        public Status Status => Status.Modified;
    }
}
