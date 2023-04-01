using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Versioning;
using System.Security.Claims;
using ToDoList.Data;
using ToDoList.Model;

namespace ToDoList.Pages
{
    public class CreateToDoListModel : PageModel
    {
        private readonly ToDoListDbContext _db;
        public UniversalList UniversalList { get; set; }

        public CreateToDoListModel(ToDoListDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(UniversalList universalList)
        {

            

            var user = _db.User.FirstOrDefault(u => u.Id == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var uniList = new UniversalList
            {
                Items = universalList.Items,
                Name = universalList.Name,
                User = user
            };

            _db.UniversalList.Add(uniList);


            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
