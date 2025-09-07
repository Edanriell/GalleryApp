using Android;
using Android.App;
using Android.OS;

[assembly: UsesPermission(Manifest.Permission.ReadMediaImages)]
[assembly: UsesPermission(Manifest.Permission.ReadExternalStorage, MaxSdkVersion = 32)]

namespace GalleryApp;

internal partial class AppPermissions
{
    internal class AppPermission : Permissions.Photos
    {
        public override (string androidPermission, bool isRuntime)[] RequiredPermissions
        {
            get
            {
                List<(string androidPermission, bool isRuntime)> perms = new();

                if (Build.VERSION.SdkInt >= BuildVersionCodes.Tiramisu)
                    perms.Add((Manifest.Permission.ReadMediaImages, true));
                else
                    perms.Add((Manifest.Permission.ReadExternalStorage, true));

                return perms.ToArray();
            }
        }
    }
}