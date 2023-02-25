using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoList.Model;

namespace ToDoList.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ToDoListDbContext _db;

        
        public List<Model.ToDoList> ToDoLists { get; set; }
        

        public IndexModel(ILogger<IndexModel> logger, ToDoListDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet()
        {
            ToDoLists = _db.ToDoLists.Include(tdl=>tdl.Items).ToList();
        }
    }
}