using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestManagement.DataAccess.Entities;
using System.Net.Http;

namespace RestManagement.DataAccess
{
    public class AppDbContext : IdentityDbContext<AppUser, IdentityRole, string>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");


            builder.Entity<ProductOrder>()
                .HasOne(p => p.Product)
                .WithMany(p => p.ProductOrders)
                .HasForeignKey(k => k.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ProductOrder>()
              .HasOne(p => p.Order)
              .WithMany(p => p.ProductOrders)
              .HasForeignKey(k => k.OrderId)
              .OnDelete(DeleteBehavior.NoAction);

        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<ProductOrder> ProductOrders { get; set; }
        public  Task<int> SaveChangesAsync(string userId,DateTime currentDate, CancellationToken cancellationToken = default)
        {
            var changeSet = ChangeTracker.Entries<BaseEntity>();

            if (changeSet != null)
            {
                foreach (var entry in changeSet.Where(c => c.State == EntityState.Added))
                {
                    entry.Entity.CreatedDate = currentDate;
                    entry.Entity.CreatedByUserId = userId;
                }
                foreach (var entry in changeSet.Where(c => c.State == EntityState.Modified))
                {
                    entry.Entity.UpdatedDate = currentDate;
                    entry.Entity.UpdatedByUserId = userId;
                }
                foreach (var entry in changeSet.Where(c => c.State == EntityState.Deleted))
                {
                    entry.Entity.UpdatedDate = currentDate;
                    entry.Entity.UpdatedByUserId = userId;
                    entry.Entity.IsDeleted = true;
                }

            }
            return SaveChangesAsync(cancellationToken);
        }
    }
}