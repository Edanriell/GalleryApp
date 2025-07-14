using System.Collections.ObjectModel;
using GalleryApp.Models;

namespace GalleryApp.Services;

internal partial class PhotoImporter : IPhotoImporter
{
    public partial Task<ObservableCollection<Photo>> Get(
        int
            start, int count, Quality quality);

    public partial Task<ObservableCollection<Photo>>
        Get(List<string> filenames, Quality quality);

    private partial Task<string[]> Import();
}