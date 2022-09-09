using Kodlama.Io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration? Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<ProgrammingLanguageTechnology> ProgrammingLanguageTechnologies { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("dzien dobry!")));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(pl =>
            {
                pl.ToTable("ProgrammingLanguages").HasKey(p => p.Id);
                pl.Property(p => p.Id).HasColumnName("Id");
                pl.Property(p => p.Name).HasColumnName("Name");
                pl.HasMany(p => p.ProgrammingLanguageTechnologies).WithOne(p => p.ProgrammingLanguage).HasForeignKey(p => p.ProgrammingLanguageId);
            });

            modelBuilder.Entity<ProgrammingLanguageTechnology>(plt =>
            {
                plt.ToTable("ProgrammingLanguageTechnologies").HasKey(p => p.Id);
                plt.Property(p => p.Id).HasColumnName("Id");
                plt.Property(p => p.Name).HasColumnName("Name");
                plt.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                plt.HasOne(p => p.ProgrammingLanguage).WithMany(p => p.ProgrammingLanguageTechnologies).HasForeignKey(p => p.ProgrammingLanguageId);
            });

            ProgrammingLanguage[] PLSeeds = { new(1, "C#"),new(2,"Java"),new(3,"Python") };
            ProgrammingLanguageTechnology[] PLTSeeds = { new(1, 1, "EntityFramework"),new(2,2,"Spring"),new(3,3,"Django") };
            

            modelBuilder.Entity<ProgrammingLanguage>().HasData(PLSeeds);
            modelBuilder.Entity<ProgrammingLanguageTechnology>().HasData(PLTSeeds);
        }
    }
}
