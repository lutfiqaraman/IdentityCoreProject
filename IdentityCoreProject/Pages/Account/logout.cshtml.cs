using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityCoreProject.Pages.Account
{
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnPostAsync()
        {
            string cookie = CookieAuthenticationDefaults.AuthenticationScheme;
            await HttpContext.SignOutAsync(cookie);

            return RedirectToPage("/Index");
        }
    }
}
