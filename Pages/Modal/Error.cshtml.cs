using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MitreAttackHelper.Pages.Modal
{
    public class ErrorModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
