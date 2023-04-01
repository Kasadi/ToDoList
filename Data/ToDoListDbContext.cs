using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using ToDoList.Model;

namespace ToDoList.Data
{
    public class ToDoListDbContext : IdentityDbContext<User>
    {
        public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options)
        {

        }

        public DbSet<Item> Item { get; set; }
        public DbSet<UniversalList> UniversalList { get; set; }
        public DbSet<User> User { get; set; }


    }
}
