using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MVCEntity
{
    public partial class ProductSearchEntity : DbContext
    {
        public ProductSearchEntity()
            : base("name=ProductSearchEntity")
        {
        }

        public virtual DbSet<ProductSearchProductTable> ProductSearchProductTable { get; set; }
        public virtual DbSet<ProductSearchUserTable> ProductSearchUserTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductSearchProductTable>()
                .Property(e => e.GoodName)
                .IsUnicode(false);

            modelBuilder.Entity<ProductSearchProductTable>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ProductSearchProductTable>()
                .Property(e => e.Weight)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ProductSearchProductTable>()
                .Property(e => e.Color)
                .IsUnicode(false);

            modelBuilder.Entity<ProductSearchProductTable>()
                .Property(e => e.Brand)
                .IsUnicode(false);

            modelBuilder.Entity<ProductSearchUserTable>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<ProductSearchUserTable>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<ProductSearchUserTable>()
                .Property(e => e.RealName)
                .IsUnicode(false);

            modelBuilder.Entity<ProductSearchUserTable>()
                .Property(e => e.Authorize)
                .IsUnicode(false);
        }
    }
}
