using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using ToDoList.Data;
using ToDoList.Model;


namespace ToDoList.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ToDoListDbContext _db;


        public User User { get; set; }


        public IndexModel(ILogger<IndexModel> logger, ToDoListDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {

            Debug.WriteLine($"Ez a cucc: {HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value}");
            User = _db.User
                .Include(u => u.UniversalList)
                    .ThenInclude(ul => ul.Items)
                        .ThenInclude(i=>i.Users)
                .Where(u => u.Id == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)
                .FirstOrDefault();

        }
    }
}