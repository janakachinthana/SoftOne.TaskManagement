
using Microsoft.EntityFrameworkCore;
using SoftOne.TaskManagement.WebAPI.Entities.Auth;
using SoftOne.TaskManagement.WebAPI.Entities.Taks;

namespace SoftOne.TaskManagement.WebAPI.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Taks> Taks { get; set; }
    }
}
