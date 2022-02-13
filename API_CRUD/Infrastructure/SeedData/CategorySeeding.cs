using API_CRUD.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_CRUD.Infrastructure.SeedData
{
    public class CategorySeeding : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category { Id = 1, Name = "Giyim", Description = "Size yakışan tüm ürünler.", Slug = "giyim" },
                            new Category { Id = 2, Name = "Aksesuar", Description = "Hem şık, hem ucuz.", Slug = "aksesuar" },
                            new Category { Id = 3, Name = "Ayakkabı", Description = "Hem konforlu, hem şık, hem ucuz.", Slug = "ayakkabı" });
        }
    }
}
