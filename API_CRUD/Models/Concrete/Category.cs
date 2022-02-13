using API_CRUD.Models.Abstract;

namespace API_CRUD.Models.Concrete
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
    }
}
