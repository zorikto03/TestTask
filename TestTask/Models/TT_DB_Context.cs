using Microsoft.EntityFrameworkCore;

namespace TestTask.Models
{
    public class TT_DB_Context : DbContext
    {
        public TT_DB_Context() 
        {
        }
        
        public TT_DB_Context(DbContextOptions<TT_DB_Context> options) 
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SalesPoint> SalesPoints { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //"Host=localhost;Port=5433;Database=TestTaskDB;Username=user;Password=qwerty"
                optionsBuilder.UseNpgsql("User ID=user;Password=qwerty;Host=testtaskdb;Port=5433;Database=TestTaskDB;Pooling=true");
            }
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

        //    builder.Entity<Product>(entity =>
        //    {
        //        entity.ToTable("product");

        //        entity.Property(e => e.Id).HasColumnName("Id");

        //        entity.Property(e=>e.Name).HasColumnName("Name");

        //        entity.Property(e => e.Price).HasColumnName("Price");
        //    });

        //    builder.Entity<Buyer>(entity =>
        //    {
        //        entity.ToTable("buyer");

        //        entity.Property(e=>e.Id).HasColumnName("Id");

        //        entity.Property(e=>e.Name).HasColumnName("Name");
        //    });

        //    builder.Entity<Sale>(entity =>
        //    {
        //        entity.ToTable("sale");
        //        entity.Property(e => e.Id);
        //        entity.Property(e => e.Date).HasColumnName("Date");
        //        entity.Property(e => e.BuyerId);
        //        entity.Property(e => e.SalesPointId);
        //        entity.Property(e => e.TotalAmount);
        //    });

        //    builder.Entity<SaleData>(entity =>
        //    {
        //        entity.ToTable("SaleData");
        //        entity.HasNoKey();

        //        entity.Property(e => e.ProductId);
        //        entity.Property(e => e.ProductQuantity);
        //        entity.Property(e => e.ProductIdAmount);
        //    });

        //    builder.Entity<SalesPoint>(entity =>
        //    {
        //        entity.ToTable("SalesPoint");

        //        entity.Property(e => e.Id);
        //        entity.Property(e => e.Name);
        //    });
        //}
    }
}
