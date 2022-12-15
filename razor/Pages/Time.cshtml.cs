using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace razor.Pages;

public class TimeModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;
    ITime t;

    public TimeModel(ILogger<PrivacyModel> logger, ITime t)
    {
        _logger = logger;
        this.t = t;
    }

    public IActionResult OnGet()
    {
        return new JsonResult(new {time=t.time()});
    }
}

