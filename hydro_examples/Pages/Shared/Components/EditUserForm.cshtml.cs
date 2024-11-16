using System.ComponentModel.DataAnnotations;
using Hydro;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace hydro_examples.Pages.Shared.Components;

public class EditUserForm : HydroComponent
{
    // private readonly IDatabase _database;

    public EditUserForm()
    {
        // _database = database;

        // Subscribe<SystemMessageEvent>(Handle);
    }

    public string UserId { get; set; }

    [Required]
    public string Name { get; set; }

    public override async Task MountAsync()
    {
        // var formData = ...; // fetch data from database

        // Name = formData.Name;
        Name = "Nick";
    }

    public override void Render()
    {
        ViewBag.IsLongName = Name.Length > 20;
    }

    public async Task Save()
    {
        // await _database.UpdateUser(UserId, Name); // save the data
        Thread.Sleep(500);
    }
    //
    // public void Handle(SystemMessageEvent message)
    // {
    //     Message = message.Text;
    //     Message = message.Text;
    // }
}
