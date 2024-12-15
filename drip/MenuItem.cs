using CodeMechanic.Types;

namespace drip;

public class MenuItem
{
    public string id { get; set; } = string.Empty;
    public string text { get; set; } = "Menu Item";
    public string view_name { get; set; } = string.Empty;
    public string badge_text { get; set; } = string.Empty;
    public string icon_path { get; set; } = string.Empty;

    // Sub menus
    public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();

    // validation
    public bool has_icon => icon_path.IsNotEmpty();
    public bool has_badge => badge_text.IsNotEmpty();
}