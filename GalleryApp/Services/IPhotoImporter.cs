using System.Collections.ObjectModel;
using GalleryApp.Models;

namespace GalleryApp.Services;

public interface IPhotoImporter
{
    Task<ObservableCollection<Photo>> Get(int start, int count, Quality quality = Quality.Low);
    Task<ObservableCollection<Photo>> Get(List<string> filenames, Quality quality = Quality.Low);
}