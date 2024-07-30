using EFCore_LibrarySystem.Models.Concretes;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace EFCore_LibrarySystem.Data;

public class LibraryDbContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authours { get; set; }


}
