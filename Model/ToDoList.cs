using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace ToDoList.Model
{
    public class ToDoList
    {
        [Key]
        public int ToDoListId { get; set; }
        [Required]
        public string Name { get; set; }=string.Empty;

        public ICollection<Item>? Items { get; set; }

    }
}
