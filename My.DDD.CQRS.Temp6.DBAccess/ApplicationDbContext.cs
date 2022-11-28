using Microsoft.EntityFrameworkCore;
using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Todos;
using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Users;

namespace My.DDD.CQRS.Temp6.DBAccess
{
  public class ApplicationDbContext : DbContext
  {

    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Todo> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Todo>()
        .HasKey(t => t.Id);

      modelBuilder.Entity<Todo>()
        .HasOne(t => t.User).WithMany(t => t.Todos)
        .HasForeignKey(t => t.UserId);


      modelBuilder.Entity<User>()
        .HasKey(t => t.Id);

      modelBuilder.Entity<User>()
        .HasMany(u => u.Todos)
        .WithOne(t => t.User);

      modelBuilder
        .Ignore<Address>()
        .Ignore<Company>()
        .Ignore<Geo>();
    }
  }
}