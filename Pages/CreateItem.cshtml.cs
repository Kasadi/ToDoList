using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using ToDoList.Data;
using ToDoList.Model;

namespace ToDoList.Pages
{
    public class CreateItemModel : PageModel
    {
        private readonly ToDoListDbContext _db;
        public Item Item { get; set; }
        public List<User> Users { get; set; }



        public CreateItemModel(ToDoListDbContext db)
        {
            _db = db;
        }


        public void OnGet()
        {
            Users = _db.User.ToList();
        }
        public async Task<IActionResult> OnPost(Item item, int listId, string[] users)
        {

            if (!_db.Item.Where(i => i.Name.Contains(item.Name)).Any())
            {
                _db.Item.Add(item);
            }


            var list = _db.UniversalList
                .Include(l => l.Items.Where(i => i.Id == item.Id))
                .FirstOrDefault(l => l.Id == listId);

            list.Items.Add(item);

            await _db.SaveChangesAsync();

            foreach (var user in users)
            {
                var itemUser = _db.Item
                .Include(i => i.Users.Where(u => u.Id == user))
                .FirstOrDefault(i => i.Id == item.Id);

                var userstoadd = _db.Users
                    .Where(u => u.Id == user)
                    .FirstOrDefault();

                itemUser.Users.Add(userstoadd);
            }
            

           


            await _db.SaveChangesAsync();



            return RedirectToPage("Index");
        }
    }
}
