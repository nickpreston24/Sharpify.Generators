using Hydro;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace drip;

public class PageCounter : HydroComponent
{
    public int Count { get; set; }

    public void Add()
    {
        Count++;
    }
}
