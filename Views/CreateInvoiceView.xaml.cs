using Bilvaerksted.ViewModels;



namespace Bilvaerksted.Views
{
    public partial class OpretFakturaView : ContentPage
    {
        public OpretFakturaView(CreateInvoiceViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

    }
}