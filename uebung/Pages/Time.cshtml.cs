using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace uebung.Pages;

public class TimeModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public TimeModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public IActionResult OnGet()
    {
        return new JsonResult(new {time=System.DateTime.Now});
    }
}
