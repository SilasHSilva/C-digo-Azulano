using Azulano.Data.Map;
using Azulano.Models.Animals;
using Azulano.Models.Habitat;
using Microsoft.EntityFrameworkCore;

namespace Azulano.Data
{
    public class MapeamentoAnimaisMarinhosDBContext : DbContext
     {
        public MapeamentoAnimaisMarinhosDBContext(DbContextOptions<MapeamentoAnimaisMarinhosDBContext> options): base(options) 
        { 
        }

        public DbSet<AnimalsModel> Animais { get; set; }
        public DbSet<HabitatModel> Habitat { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnimalsMap());
            modelBuilder.ApplyConfiguration(new HabitatMap());

            modelBuilder.Entity<AnimalsModel>()
            .HasOne(a => a.Habitat)
            .WithMany(u => u.Animais)
            .HasForeignKey(a => a.HabitatId)
            .HasConstraintName("FK_AnimalsModel_Habitat");

            modelBuilder.Entity<HabitatModel>()
                .HasKey(h => h.Id);

            modelBuilder.Entity<AnimalsModel>()
                .HasKey(a => a.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}