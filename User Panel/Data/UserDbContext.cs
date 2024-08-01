using Microsoft.EntityFrameworkCore;
using System.Configuration;
using User_Panel.Models;

namespace User_Panel.Data;

public class UserDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    }


    public DbSet<User> Users { get; set; }

}
