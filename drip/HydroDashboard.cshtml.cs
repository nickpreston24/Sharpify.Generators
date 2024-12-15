using Hydro;

namespace drip;

public class HydroDashboard : HydroView
{
    public MenuItem[] Items { get; set; } = Array.Empty<MenuItem>();

    public MenuItem SelectedItem { get; set; }

    public void Select(int id)
    {
        SelectedItem = Items.FirstOrDefault(i => i.id.Equals(id));
    }
}