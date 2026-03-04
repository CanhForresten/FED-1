using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using Bilvaerksted.Data;
using Bilvaerksted.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Bilvaerksted.ViewModels;

public partial class CreateInvoiceViewModel : ObservableObject
{
    public readonly Database _database;
    public Invoice Invoice { get; set; } = new();
    public ObservableCollection<Material> Materials { get; set; } = new();

    [ObservableProperty]
    private int jobId;

    [ObservableProperty]
    private string? mechanicName = string.Empty;

    [ObservableProperty]
    private string? materialName = string.Empty;

    [ObservableProperty]
    private string? materialPrice = string.Empty;

    [ObservableProperty]
    private string? hours = string.Empty;

    [ObservableProperty]
    private string? hourPrice = string.Empty;

    public CreateInvoiceViewModel(Database database)
    {
        _database = database;
    }

    [RelayCommand]
    public void AddMaterial()
    {
        if (int.TryParse(MaterialPrice, out var price))
        {
            Materials.Add(new Material
            {
                Name = MaterialName,
                Price = price
            });
            MaterialName = "";
            MaterialPrice = "";
        }
    }

    [RelayCommand]
    public async Task AddInvoice()
    {
        if (!int.TryParse(Hours, out var hoursInt)) return;
        if (!int.TryParse(HourPrice, out var priceInt)) return;

        var invoice = new Invoice
        {
            JobId = JobId,
            MechanicName = MechanicName,
            Hours = hoursInt,
            HourPrice = priceInt,
            Materials = Materials
        };

        await _database.SaveInvoiceAsync(invoice);

        Materials.Clear();
        JobId = 0;
        MechanicName = "";
        Hours = "";
        HourPrice = "";
    }


}