using Imc.Maui.ViewModels;

namespace Imc.Maui.Views;

public partial class NewPage : ContentPage
{
    public NewPage()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
    }

    private void InitializeComponent()
    {
        throw new NotImplementedException();
    }
}