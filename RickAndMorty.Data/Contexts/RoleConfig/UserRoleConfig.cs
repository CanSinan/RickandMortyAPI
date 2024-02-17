using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RickAndMorty.Data.Entities;

namespace RickAndMorty.Data.Contexts.Config
{
    public class UserRoleConfig : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasData(
                new UserRole
                {
                    Id = 1,
                    Name = "Admin",
                },
                new UserRole
                {
                    Id = 2,
                    Name = "User",
                });
        }
    }
}