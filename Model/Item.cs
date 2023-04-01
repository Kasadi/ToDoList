using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;

namespace ToDoList.Model
{
    [Index(nameof(Name), IsUnique = true)]
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;


        public ICollection<UniversalList>? UniversalList { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
