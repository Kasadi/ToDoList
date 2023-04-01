using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace ToDoList.Model
{
    public class UniversalList
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<Item>? Items { get; set; }
        public User User { get; set; }

    }
}
