using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using Bilvaerksted.Data;
using Bilvaerksted.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Bilvaerksted.ViewModels;

public partial class ShowInvoiceViewModel : ObservableObject
{
    public Database _database;
    private ObservableCollection<Invoice> allInvoices = new();

    [ObservableProperty]
    private ObservableCollection<Invoice> filteredInvioces = new();

    [ObservableProperty]
    private string searchText = string.Empty;

    public ShowInvoiceViewModel(Database database)
    {
        _database = database;
        _ = GetInvoiceAsync();
    }

    partial void OnSearchTextChanged(string value)
    {
        Filter();
    }

    private void Filter()
    {
        if (string.IsNullOrWhiteSpace(SearchText))
        {
            FilteredInvioces = new ObservableCollection<Invoice>(allInvoices);
        }
        else
        {
            var filtered = allInvoices.Where(i => i.JobId.ToString().Contains(SearchText));
            FilteredInvioces = new ObservableCollection<Invoice>(filtered);
        }
    }

    [RelayCommand]
    public async Task GetInvoiceAsync()
    {
        var result = await _database.GetInvoiceAsync();
        allInvoices = new ObservableCollection<Invoice>(result);
        Filter();
    }
    
}