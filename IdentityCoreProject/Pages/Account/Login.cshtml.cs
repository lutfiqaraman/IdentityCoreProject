using IdentityCoreProject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace IdentityCoreProject.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential? Credential { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string cookie = CookieAuthenticationDefaults.AuthenticationScheme;

            if (!ModelState.IsValid)
                return Page();

            if (Credential != null)
            {
                if (Credential.UserName == "admin" && Credential.Password == "password")
                {
                    List<Claim>? claims = new List<Claim> 
                    { 
                        new Claim(ClaimTypes.Name, Credential.UserName),
                        new Claim(ClaimTypes.Email, "admin@mywebsite.com")
                    };

                    ClaimsIdentity? identity = new ClaimsIdentity(claims, cookie);
                    ClaimsPrincipal claimPrincipal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(cookie, claimPrincipal);

                    return 
                        RedirectToPage("/Index");
                }
            }

            return Page();
        }
    }
}
