using Domain.Tickets.Entities;
using Domain.Users.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra.AppDbContexes;

public class Role : IdentityRole<Guid> { }

public class AppDbContext : DbContext//IdentityDbContext<User, Role, Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasOne(t => t.CreatedByUser)
                  .WithMany(u => u.CreatedTickets)
                  .HasForeignKey(t => t.CreatedByUserId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(t => t.AssignedToUser)
                  .WithMany()
                  .HasForeignKey(t => t.AssignedToUserId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasMany(u => u.CreatedTickets)
                  .WithOne(t => t.CreatedByUser)
                  .HasForeignKey(t => t.CreatedByUserId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }
}