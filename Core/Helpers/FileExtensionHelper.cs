using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers;

public static class FileExtensionHelper
{
    public static readonly List<string> ImageExtensions = new List<string> {
        ".png",".jpg", ".webp", ".gif"
    };

    public static bool IsImage(this FileInfo file) => ImageExtensions.Any(e => e == file.Extension);

    public static readonly List<string> RegularArchiveExtensions = new List<string> {
        ".7z", ".rar",".zip"
    };

    public static bool IsRegular(this FileInfo file) => ImageExtensions.Any(e => e == file.Extension);

    public static readonly List<string> ComixArchiveExtensions = new List<string> {
        ".c7z", ".crar",".czip", "cbz"
    };

    public static bool IsComixArchive(this FileInfo file) => ComixArchiveExtensions.Any(e => e == file.Extension);

    public static IEnumerable<string> AllArchiveExtensions => RegularArchiveExtensions.Concat(ComixArchiveExtensions);
    public static bool IsArchive(this FileInfo file) => AllArchiveExtensions.Any(e => e == file.Extension);

    public static readonly List<string> AnimationExtension = new List<string> {
        ".gif"
    };

    public static bool IsAnimation(this FileInfo file) => AnimationExtension.Any(e => e == file.Extension);

    public static string GetFileExtension(this string fullFileName)
    {
        var retVal = string.Empty;

        if (!string.IsNullOrEmpty(fullFileName))
        {
            var dotPosition = fullFileName.LastIndexOf('.');

            retVal = fullFileName.Substring(dotPosition);
        }

        return retVal;
    }
}
