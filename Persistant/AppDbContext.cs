using Domain.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;
using System.Reflection.Metadata;
namespace persistant
{
    public class AppDbContext : IdentityDbContext<User, Role, Guid>
    {
        public IConfiguration Configuration { get; }
        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)

        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("IdentityConnection"), builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });
        }


        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Lang>().HasData(
        //    new Lang { Id = 1, Code = "fa", name = "فارسی" },
        //    new Lang { Id = 2, Code = "en", name = "English" },
        //    new Lang { Id = 3, Code = "ar", name = "Arabic" }
        //);

        //    foreach (var relationship in builder.Model.GetEntityTypes()
        //             .SelectMany(e => e.GetForeignKeys()))
        //    {
        //        relationship.DeleteBehavior = DeleteBehavior.Restrict;
        //    }
        //    base.OnModelCreating(builder);
        //    builder.Entity<ProjectTranslation>()
        //     .HasOne(pt => pt.Project)
        //     .WithMany(p => p.Translations)
        //     .HasForeignKey(pt => pt.ProjectId);

        //}


    }
}


