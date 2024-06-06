using Azulano.Models.Animals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Azulano.Data.Map
{
    public class AnimalsMap : IEntityTypeConfiguration<AnimalsModel>
    {
        public void Configure(EntityTypeBuilder<AnimalsModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.NomeCientifico).IsRequired().HasMaxLength(225);
            builder.Property(x => x.NomeComum).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Descricao).IsRequired();

            builder.HasOne(x => x.Habitat)
                   .WithMany()
                   .HasForeignKey(x => x.HabitatId);
        }
    }
}