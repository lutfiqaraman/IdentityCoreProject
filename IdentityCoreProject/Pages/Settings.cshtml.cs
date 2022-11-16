using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityCoreProject.Pages
{
    [Authorize(Policy = "AdminDepartment")]
    public class SettingsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
