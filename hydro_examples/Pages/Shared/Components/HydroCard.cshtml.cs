using Hydro;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace hydro_examples.Pages.Shared.Components;

[HtmlTargetElement("card")]
public class HydroCard : HydroView
{
    public string title { get; set; } = string.Empty;
}