using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using Bilvaerksted.Data;
using Bilvaerksted.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
public partial class BookViewModel : ObservableObject
{
    public Database database_;
    public Job job_ { get; set; } = new();


    [ObservableProperty]
    private int jobId;
    [ObservableProperty]
    private string custommerName;
    [ObservableProperty]
    private string custommerAdress;
    [ObservableProperty]
    private string make;
    [ObservableProperty]
    private string model;
    [ObservableProperty]
    private string registration;

    [ObservableProperty]
    private DateTime date = DateTime.Now;

    [ObservableProperty]
    private string task;

    public BookViewModel()
    {
        database_ = new Database();
    }

    [RelayCommand]
    public async Task AddJob()
    {
        job_ = new Job
        {
            CustommerName = CustommerName,
            CustommerAdress = CustommerAdress,
            Make = Make,
            Model = Model,
            Registration = Registration,
            Date = Date,
            Task = Task
        };
        var inserted = await database_.AddJob(job_);
        if (inserted != 0)
        {
            CustommerName = string.Empty;
            CustommerAdress = string.Empty;
            Make = string.Empty;
            Model = string.Empty;
            Registration = string.Empty;
            Task = string.Empty;
            Date = DateTime.Now;
        }
    }
}

