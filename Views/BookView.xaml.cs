
namespace Bilvaerksted.Views;

public partial class BookView : ContentPage
{
    public BookView()
    {
        InitializeComponent();
        BindingContext = new BookViewModel();
    }

}