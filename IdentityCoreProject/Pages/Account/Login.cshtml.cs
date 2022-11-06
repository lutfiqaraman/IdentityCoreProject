using IdentityCoreProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityCoreProject.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential? Credential { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
                return;


        }
    }
}
