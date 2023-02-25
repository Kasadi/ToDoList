using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;

namespace ToDoList.Model
{
    [Index(nameof(Name), IsUnique = true)]
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        [Required]

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;


        public ICollection<ToDoList>? ToDoLists { get; set; }
    }
}
