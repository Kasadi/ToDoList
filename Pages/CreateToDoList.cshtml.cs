using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.Model;

namespace ToDoList.Pages
{
    public class CreateToDoListModel : PageModel
    {
        private readonly ToDoListDbContext _db;
        public Model.ToDoList ToDoList { get; set; }

        public CreateToDoListModel(ToDoListDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(Model.ToDoList toDoList)
        {
            await _db.AddAsync(toDoList);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
