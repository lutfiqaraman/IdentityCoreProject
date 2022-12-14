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
                        new Claim(ClaimTypes.Email, "admin@mywebsite.com"),
                        new Claim("HR", "HRDepartment"),
                        new Claim("Admin", "AdminDepartment"),
                        new Claim("EmploymentDate", "2022-01-01")
                    };

                    ClaimsIdentity? identity = new ClaimsIdentity(claims, cookie);
                    ClaimsPrincipal claimPrincipal = new ClaimsPrincipal(identity);

                    AuthenticationProperties? authProperties = new()
                    {
                        IsPersistent = Credential.RememberMe
                    };

                    await HttpContext.SignInAsync(cookie, claimPrincipal, authProperties);

                    return 
                        RedirectToPage("/Index");
                }
            }

            return Page();
        }
    }
}
