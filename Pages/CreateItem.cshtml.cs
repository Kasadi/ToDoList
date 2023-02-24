using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text;
using ToDoList.Model;

namespace ToDoList.Pages
{
    public class CreateItemModel : PageModel
    {
        private readonly ToDoListDbContext _db;
        public Item Item { get; set; }
        public Model.ToDoList ToDoList { get; set; }
        public List<Model.ToDoList> ToDoLists { get; set; }



        public CreateItemModel(ToDoListDbContext db)
        {
            _db = db;
        }


        public void OnGet()
        {
            ToDoLists = _db.ToDoLists.ToList();
        }
        public async Task<IActionResult> OnPost(Item item, Model.ToDoList toDoList)
        {
            _db.Items.Add(item);

            var list = _db.ToDoLists
                .Include(l => l.Items.Where(i => i.ItemId == item.ItemId))
                .FirstOrDefault(l => l.ToDoListId == toDoList.ToDoListId);

            list.Items.Add(item);



            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}