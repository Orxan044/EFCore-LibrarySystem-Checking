using EFCore_LibrarySystem.Models.Concretes;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace EFCore_LibrarySystem.Data;

public  class AdminDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["constrAdmin"].ConnectionString);

    }


    public DbSet<Admin> Admins { get; set; }
}
