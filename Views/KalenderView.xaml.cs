
using Bilvaerksted.ViewModels;

namespace Bilvaerksted.Views;

public partial class KalenderView : ContentPage
{
    public KalenderView()
    {
        InitializeComponent();
        BindingContext = new KalenderViewModel();
    }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is KalenderViewModel vm)
        {
            // Så kalder vi metoden, der henter jobs og opdaterer kalenderen
            await vm.LoadData();
        }
        }
        
}