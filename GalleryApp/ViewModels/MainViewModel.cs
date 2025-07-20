using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using GalleryApp.Models;
using GalleryApp.Services;

namespace GalleryApp.ViewModels;

public partial class MainViewModel : ViewModel
{
    private readonly ILocalStorage localStorage;
    private readonly IPhotoImporter photoImporter;

    [ObservableProperty] private ObservableCollection<Photo> favorites;

    [ObservableProperty] private ObservableCollection<Photo> recent;

    public MainViewModel(IPhotoImporter photoImporter, ILocalStorage localStorage)
    {
        this.photoImporter = photoImporter;
        this.localStorage = localStorage;
    }

    protected internal override async Task Initialize()
    {
        var photos = await photoImporter.Get(0, 20);

        Recent = photos;
        await LoadFavorites();

        WeakReferenceMessenger.Default.Register<string>(this, async (sender, message) =>
        {
            if (message == Services.Messages.FavoritesAddedMessage)
                await MainThread.InvokeOnMainThreadAsync(LoadFavorites);
        });
    }

    private async Task LoadFavorites()
    {
        var filenames = localStorage.Get();
        var favorites = await photoImporter.Get(filenames);

        Favorites = favorites;
    }
}