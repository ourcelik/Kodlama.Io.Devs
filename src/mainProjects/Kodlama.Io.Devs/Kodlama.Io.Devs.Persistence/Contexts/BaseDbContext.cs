
using Core.Security.Entities;
using Core.Security.Enums;
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
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<GithubAccount> GithubAccounts { get; set; }

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

            modelBuilder.Entity<User>(u =>
            {
                u.ToTable("Users").HasKey(p => p.Id);
                u.Property(p => p.Id).HasColumnName("Id");
                u.Property(p => p.Username).HasColumnName("Username");
                u.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                u.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
                u.Property(p => p.Email).HasColumnName("Email");
                u.Property(p => p.FirstName).HasColumnName("FirstName");
                u.Property(p => p.LastName).HasColumnName("LastName");
                u.Property(p => p.Status).HasColumnName("Status");
                u.HasMany(p => p.UserOperationClaims).WithOne(p => p.User).HasForeignKey(p => p.UserId);
            });

            modelBuilder.Entity<OperationClaim>(oc =>
            {
                oc.ToTable("OperationClaims").HasKey(p => p.Id);
                oc.Property(p => p.Id).HasColumnName("Id");
                oc.Property(p => p.Name).HasColumnName("Name");
            });
            modelBuilder.Entity<UserOperationClaim>(uoc =>
            {
                uoc.ToTable("UserOperationClaims").HasKey(p => p.Id);
                uoc.Property(p => p.Id).HasColumnName("Id");
                uoc.Property(p => p.UserId).HasColumnName("UserId");
                uoc.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
                uoc.HasOne(p => p.User).WithMany(p => p.UserOperationClaims).HasForeignKey(p => p.UserId);
                uoc.HasOne(p => p.OperationClaim).WithMany(p => p.UserOperationClaims).HasForeignKey(p => p.OperationClaimId);
            });
            modelBuilder.Entity<RefreshToken>(rt =>
            {
                rt.ToTable("RefreshTokens").HasKey(p => p.Id);
                rt.Property(p => p.Id).HasColumnName("Id");
                rt.Property(p => p.Token).HasColumnName("Token");
                rt.Property(p => p.Expires).HasColumnName("Expiration");
                rt.Property(p => p.UserId).HasColumnName("UserId");
                rt.HasOne(p => p.User).WithMany(p => p.RefreshTokens).HasForeignKey(p => p.UserId);
            });

            modelBuilder.Entity<GithubAccount>(ga =>
            {
                ga.ToTable("GithubAccounts").HasKey(p => p.Id);
                ga.Property(p => p.Id).HasColumnName("Id");
                ga.Property(p => p.UserId).HasColumnName("UserId");
                ga.Property(p => p.Url).HasColumnName("Url");
                ga.Property(p => p.Username).HasColumnName("Username");
                ga.Property(p => p.PublicRepos).HasColumnName("PublicRepos");
                ga.HasOne(p => p.User);
            });

            ProgrammingLanguage[] PLSeeds = { new(1, "C#"),new(2,"Java"),new(3,"Python") };
            ProgrammingLanguageTechnology[] PLTSeeds = { new(1, 1, "EntityFramework"),new(2,2,"Spring"),new(3,3,"Django") };
            OperationClaim[] OCSeeds = { new(1, "Admin"), new(2, "User") };
            User[] UserSeeds = { new(1, "admin","admin", "admin","admin",Encoding.UTF8.GetBytes("admin"),Encoding.UTF8.GetBytes("admin"),true,AuthenticatorType.Email)};
            UserOperationClaim[] UOCSeeds = { new(1, 1, 1) };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(PLSeeds);
            modelBuilder.Entity<ProgrammingLanguageTechnology>().HasData(PLTSeeds);
            modelBuilder.Entity<OperationClaim>().HasData(OCSeeds);
            modelBuilder.Entity<User>().HasData(UserSeeds);
        }
       
    }

}
