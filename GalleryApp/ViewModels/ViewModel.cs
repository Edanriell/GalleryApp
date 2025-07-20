using CommunityToolkit.Mvvm.ComponentModel;

namespace GalleryApp.ViewModels;

public abstract partial class ViewModel : ObservableObject
{
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    private bool isBusy;

    public bool IsNotBusy => !IsBusy;

    protected internal abstract Task Initialize();
}