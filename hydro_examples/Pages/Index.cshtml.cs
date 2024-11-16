using Microsoft.AspNetCore.Mvc.RazorPages;

namespace hydro_examples.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public List<MenuItem> MenuItems { get; set; } =
        new List<MenuItem>()
        {
            new MenuItem() { view_name = "Account" },
            new MenuItem() { view_name = "Parts" },
            new MenuItem() { view_name = "Aircraft" },
        };
}
