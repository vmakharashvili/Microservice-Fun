
using Microsoft.EntityFrameworkCore;

namespace MicroserviceFun.Users.Data;
public class UsersDbContext : DbContext
{
    public UsersDbContext(DbContextOptions<UsersDbContext> options): base(options)
    {

    }

    public DbSet<User> Users => Set<User>();
}
