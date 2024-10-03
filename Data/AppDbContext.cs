using Microsoft.EntityFrameworkCore;
using SimpleRestApiPostgres.Models;

namespace SimpleRestApiPostgres.Data
{
    public class AppDbContext : DbContext
    {

        // Constructor

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        // Properties
        public DbSet<ToDoItem> ToDoItem { get; set; } = null!;


    }
}
