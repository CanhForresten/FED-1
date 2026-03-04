
namespace Bilvaerksted.Views;

public partial class BookView : ContentPage
{
    public BookView(BookViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

}