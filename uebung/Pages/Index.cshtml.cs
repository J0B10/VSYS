using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace uebung.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public String Message { get; set; } = "Demo Text";
    public IMessage Msg { get; }

    public IndexModel(ILogger<IndexModel> logger, IMessage msg)
    {
        _logger = logger;
        Msg = msg;
    }

    public void OnGet()
    {
        Message = Msg.getMessage();
    }
}
