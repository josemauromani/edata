using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntitiesConfig
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Sobrenome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Cpf).HasMaxLength(14).IsRequired();
            builder.Property(p => p.DataNascimento).IsRequired();
        }
    }
}
