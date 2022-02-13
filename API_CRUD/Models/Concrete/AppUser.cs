using API_CRUD.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_CRUD.Models.Concrete
{
    public class AppUser : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        [NotMapped]
        public string Token { get; set; }
    }
}
