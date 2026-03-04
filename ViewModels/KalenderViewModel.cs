using System.Collections.ObjectModel;
using System.ComponentModel;
using Bilvaerksted.Models;
using Bilvaerksted.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using Bilvaerksted.Data;

namespace Bilvaerksted.ViewModels;

public partial class KalenderViewModel: ObservableObject
{
    public Database _database; 
    private List<Job> _allJobs = new List<Job>();

    [ObservableProperty]
    private DateTime _selectedDate = DateTime.Today;

    [ObservableProperty]
    private ObservableCollection<Job> _selectedDateJobs = new();

    public KalenderViewModel(Database database)
    {
        Task.Run(async() =>
        {
            _database = database;
            await LoadData();
        });
    }

    // Ved tryk af dato
    partial void OnSelectedDateChanged(DateTime value)
    {
        FilterJobsForSelectedDate();
    }

    // Hent data fra databasen
    public async Task LoadData()
    {
        var JobsDB = await _database.GetJobs();
        _allJobs = JobsDB;


        FilterJobsForSelectedDate();
    }

    // Sortere data ud fra dato
    private void FilterJobsForSelectedDate()
    {
        var JobsFound = _allJobs.Where(j => j.Date.Date == SelectedDate.Date).ToList();

        MainThread.BeginInvokeOnMainThread(() =>
        {
            SelectedDateJobs.Clear();
            foreach (var job in JobsFound)
            {   
                SelectedDateJobs.Add(job);
            }
        });

    }

}