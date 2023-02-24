using ToDoList.Model;

namespace ToDoList.Dto
{
    public class ListItemDto
    {
        public Model.ToDoList ToDoList { get; set; }
        public Item Item { get; set; }
    }
}
