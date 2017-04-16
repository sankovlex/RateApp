using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Rate.Models.Domain;
using System.Threading.Tasks;

namespace Rate.Data.Core
{
    public class EfContext : DbContext, IEfContext
    {
        #region Tables
        public DbSet<Currency> Currencies { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // requires
            modelBuilder.Entity<Currency>()
                .Property(p => p.PurchasePrice)
                .IsRequired();

            modelBuilder.Entity<Currency>()
                .Property(p => p.SellingPrice)
                .IsRequired();

            modelBuilder.Entity<Currency>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(3);

            // default value date on add
            modelBuilder.Entity<Currency>()
                .Property(p => p.DateCreate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("getdate()");

            //indexes
            modelBuilder.Entity<Currency>()
                .HasIndex(p => p.Name);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=rate_db;Integrated Security=True");
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public new EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return base.Entry(entity);
        }

        public new int SaveChanges()
        {
            return base.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
