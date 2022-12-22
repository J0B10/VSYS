using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace uebung.Pages;

public class MessageModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public IMessage Msg { get; }
    public MessageModel(ILogger<IndexModel> logger, IMessage msg)
    {
        _logger = logger;
        Msg = msg;
    }

    public IActionResult OnGet()
    {
        return new JsonResult(new {message=Msg.getMessage()});
    }
}
