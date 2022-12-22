using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace uebung.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public String Message { get; set; } = "Demo Text";
    public IMessage Msg { get; }
    
    [BindProperty(SupportsGet = true)]
    public int a { get; set; }
    [BindProperty(SupportsGet = true)]
    public int b { get; set; }

    public IndexModel(ILogger<IndexModel> logger, IMessage msg)
    {
        _logger = logger;
        Msg = msg;
    }

    public void OnGet(/*int a, int b*/)
    {
        // this.a = a;
        // this.b = b;
        Message = $"Summe = {a+b}";
    }
}
