using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace razor.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    [BindProperty]
    public String Message { get; set; } = "Message";

    [BindProperty]
    public String Text { get; set; } = "Text";

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(string Message, string Text)
    {
        _logger.LogInformation("I've got a GET request");
    }

    public void OnPostEdit()
    {
        _logger.LogInformation("I've got a POST request");
        // this.Message = Message;
        // this.Text = Text;
    }
}
