using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationContext : IdentityDbContext<IdentityUser>
{
  public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
  {
  }

  public DbSet<MenuItem> MenuItems { get; set; }
  public DbSet<Customer> Customers { get; set; }
  public DbSet<Table> Tables { get; set; }
  public DbSet<Booking> Bookings { get; set; }
}