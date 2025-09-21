using Domain;   
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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


        protected override void OnModelCreating(ModelBuilder builder)
        {
        //    builder.Entity<Lang>().HasData(
        //    new Lang { Id = 1, Code = "fa", name = "فارسی" },
        //    new Lang { Id = 2, Code = "en", name = "English" },
        //    new Lang { Id = 3, Code = "ar", name = "Arabic" }
        //);
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            //About selfRefrensing
            builder.Entity<User>()
       .HasMany(u => u.referres)   // هر بازاریاب می‌تونه چند مشتری داشته باشه
       .WithOne(u => u.Referrer)            // هر مشتری یک معرف داره
       .HasForeignKey(u => u.ReferrerId)    // کلید خارجی
       .OnDelete(DeleteBehavior.Restrict);  // حذف معرف، مشتری‌ها رو پاک نکنه

            //about OneToOne
          builder.Entity<User>()
         .HasOne(c => c.UserInfo)
         .WithOne(ui => ui.user)
         .HasForeignKey<UserInfo>(x => x.UserId)
          .OnDelete(DeleteBehavior.Restrict);
           
            builder.Entity<UserInfo>()
           .HasIndex(ui => ui.UserId)
           .IsUnique();


            base.OnModelCreating(builder);
            


        }
        
        public DbSet<CategoryFoodPlan> categoryFoodPlans { get; set; } 
        public DbSet<City> City { get; set; } 
       
        public DbSet<Food> Food { get; set; } 
        public DbSet<Foodplan> Foodplan { get; set; } 
        public DbSet<OrderItems> OrderItems { get; set; } 
        public DbSet<Opinion> Opinion { get; set; } 
        public DbSet<Orders> Orders { get; set; } 
        public DbSet<Sickness> Sickness { get; set; } 
        public DbSet<Spice> Spice { get; set; } 
        public DbSet<State> State { get; set; } 
        public DbSet<Symptoms> Symptoms { get; set; } 
        public DbSet<UserInfo> UserInfo { get; set; } 
        public DbSet<Vitamins> Vitamins { get; set; } 
 
   

    }
}
            //builder.Entity<ProjectTranslation>()
            // .HasOne(pt => pt.Project)
            // .WithMany(p => p.Translations)
            // .HasForeignKey(pt => pt.ProjectId);


