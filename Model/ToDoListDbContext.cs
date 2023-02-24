using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace ToDoList.Model
{
    public class ToDoListDbContext : DbContext
    {
        public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }


    }
}
