
using Core.Entity.Models;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=FinalProjectoDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<UselessUser> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<OfferType> OfferTypes { get; set; }
        public DbSet<OwnerType> OwnerTypes { get; set; }
        public DbSet<DrivingType> DrivingTypes { get; set; }
        public DbSet<BodyType> BodyTypes { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

    }
}
