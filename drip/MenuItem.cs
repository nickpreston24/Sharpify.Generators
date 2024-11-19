using CodeMechanic.Types;

namespace drip;

public class MenuItem
{
    public bool has_icon => icon_path.IsNotEmpty();
    public bool has_badge => badge_text.IsNotEmpty();

    public string view_name { get; set; } = string.Empty;
    public string badge_text { get; set; } = string.Empty;
    public string icon_path { get; set; } = string.Empty;

    public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    public string text { get; set; } = "Menu Item";
}
