using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Azulano.Models.Habitat;

namespace Azulano.Data.Map
{
    public class HabitatMap : IEntityTypeConfiguration<HabitatModel>
    {
        public void Configure(EntityTypeBuilder<HabitatModel> builder)
        {
            builder.ToTable("Habitat");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.NameHabitat)
                .IsRequired()
                .HasMaxLength(225);

            builder.Property(x => x.DescricaoHabitat)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Localizacao)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}