using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.Model;

namespace ToDoList.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

       
        public RegisterModel(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnPostRegister(string username, string password)
       
        {


            var user = new User { UserName = username };

            var result = await _userManager.CreateAsync(user,password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Redirect("/Index");
            }

            return RedirectToPage();


        }
    }
}
