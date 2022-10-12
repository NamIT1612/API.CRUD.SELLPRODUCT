using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MISA.SHOPPRODUCT.Models
{
    public partial class SHOP : DbContext
    {
        public SHOP()
            : base("name=SHOP")
        {
        }

        public virtual DbSet<CART> CARTs { get; set; }
        public virtual DbSet<CLIENT> CLIENTs { get; set; }
        public virtual DbSet<PRODUCT> PRODUCTs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CLIENT>()
                .Property(e => e.NUMBERPHONE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .HasMany(e => e.CARTs)
                .WithRequired(e => e.CLIENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRODUCT>()
                .HasMany(e => e.CARTs)
                .WithRequired(e => e.PRODUCT)
                .WillCascadeOnDelete(false);
        }
    }
}
