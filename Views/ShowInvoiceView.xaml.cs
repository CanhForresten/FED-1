using Bilvaerksted.ViewModels;



namespace Bilvaerksted.Views
{
    public partial class SeFakturaView : ContentPage
    {
        public SeFakturaView(ShowInvoiceViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ((ShowInvoiceViewModel)BindingContext).GetInvoiceAsync();
        }

    }
}