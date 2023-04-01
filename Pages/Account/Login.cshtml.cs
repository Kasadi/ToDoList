using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.Model;

namespace ToDoList.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        public LoginModel(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostLogin(string username, string password)
        {

            var user = await _userManager.FindByNameAsync(username);
            if (user!=null)
            {
                await _signInManager.PasswordSignInAsync(user, password, false, false);
                return Redirect("/Index");
            }
            return RedirectToPage();
          


            
        }
    }
}
