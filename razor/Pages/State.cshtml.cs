using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace razor.Pages;

public class StateModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;

    public int Nr { get; set; }
    public StateModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    public void OnPost()    // Hidden fields -> add OnPost(int Nr)
    {
        _logger.LogInformation("Click "+Nr);
        //this.Nr = ++Nr;

        // Soft State
        Nr = HttpContext.Session.GetInt32("cnt")??0;
        Nr++;
        HttpContext.Session.SetInt32("cnt", Nr);

        // Cookies
        // string? c = HttpContext.Request.Cookies["cnt"];
        // if (c != null) Nr = Int32.Parse(c);
        // ++Nr;
        // HttpContext.Response.Cookies.Append("cnt", Nr.ToString());
    }
}

