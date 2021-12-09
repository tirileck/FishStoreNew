using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FishStore.Entities;
using FishStore.Entities.Products;
using FishStore.Entities.Products.ProductDicts;
using FishStore.Entities.Accounting;

namespace FishStore.EF.Contextst
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options)
               : base(options)
        { }
        #region DbSets
        public DbSet<BaseObject> BaseObjects { get; set; }
        public DbSet<TypeObject> TypeObjects { get; set; }
        public DbSet<DictObject> DictObjects { get; set; }
        public DbSet<ProductObject> ProductObjects { get; set; }
        public DbSet<TypeOfClothing> TypesOfClothing { get; set; }
        public DbSet<TypeOfBait> TypesOfBait { get; set; }
        public DbSet<TypeOfRod> TypesOfRod { get; set; }
        public DbSet<TypeOfGear> TypesOfGear { get; set; }
        public DbSet<Clothing> Clothing { get; set; }
        public DbSet<Rod> Rod { get; set; }
        public DbSet<Bait> Bait { get; set; }
        public DbSet<Gear> Gear { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<BaseObject>().ToTable("BaseObjects");
            modelBuilder.Entity<TypeObject>().ToTable("TypeObjects");
            modelBuilder.Entity<DictObject>().ToTable("DictObjects");
            modelBuilder.Entity<ProductObject>().ToTable("ProductObjects");
            modelBuilder.Entity<TypeOfClothing>().ToTable("TypesOfClothing");
            modelBuilder.Entity<TypeOfBait>().ToTable("TypesOfBait");
            modelBuilder.Entity<TypeOfRod>().ToTable("TypesOfRod");
            modelBuilder.Entity<TypeOfGear>().ToTable("TypesOfGear");
            modelBuilder.Entity<Clothing>().ToTable("Clothings");
            modelBuilder.Entity<Rod>().ToTable("Rods");
            modelBuilder.Entity<Bait>().ToTable("Baits");
            modelBuilder.Entity<Gear>().ToTable("Gears");
            modelBuilder.Entity<Role>().ToTable("Roles").HasData(
                new Role() { ID=100, Name = "User" },
                new Role() { ID=101, Name = "Admin" }
            );
            modelBuilder.Entity<User>().ToTable("Users").HasAlternateKey(u => u.Email);

        }
    }
}