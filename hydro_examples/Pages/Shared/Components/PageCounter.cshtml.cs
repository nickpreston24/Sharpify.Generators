using Hydro;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace hydro_examples.Pages.Shared.Components;

public class PageCounter : HydroComponent
{
    public int Count { get; set; }

    public void Add()
    {
        Count++;
    }
}
