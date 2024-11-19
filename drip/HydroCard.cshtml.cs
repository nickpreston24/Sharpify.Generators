using Hydro;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace drip;

[HtmlTargetElement("card")]
public class HydroCard : HydroView
{
    public string title { get; set; } = string.Empty;
}