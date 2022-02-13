using API_CRUD.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_CRUD.Infrastructure.SeedData
{
    public class AppUserSeeding : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasData(new AppUser { Id = 1, UserName = "Emre", Password = "123" },
                            new AppUser { Id = 2, UserName = "Erkan", Password = "123" },
                            new AppUser { Id = 3, UserName = "Erol", Password = "123" });
        }
    }
}
