using GalleryApp.ViewModels;

namespace GalleryApp.Views;

public partial class MainView : ContentPage
{
    public MainView(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        MainThread.InvokeOnMainThreadAsync(viewModel.Initialize);
    }
}