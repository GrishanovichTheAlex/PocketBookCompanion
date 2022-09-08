using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers;

public static class FileExtension
{
    public static string GetFolderName(this FileInfo file)
    {
        return file.DirectoryName ?? string.Empty;
    }

    public static string GetFolderName(this DirectoryInfo directory)
    {
        return directory.Name;
    }

    public static string GetFolderName(this string path)
    {
        string retVal;

        if (Directory.Exists(path))
        {
            retVal = new DirectoryInfo(path).GetFolderName();
        }
        else
        {
            retVal = new FileInfo(path).GetFolderName();
        }

        return retVal;
    }

    public static string GetFileNameWithoutExtension(this FileInfo file)
    {
        string retVal = null;

        if (file != null)
        {
            retVal = file.Name.Substring(0, file.Name.Length - (file.Extension.Length));
        }

        return retVal ?? string.Empty;
    }

    public static string CopyAsComixArchive(this FileInfo file, bool @override = false)
    {
        var path = Path.Combine(
            @"C:\\Users\\grish\\OneDrive\\Desktop",
            file.GetFileNameWithoutExtension() + ".cbz");

        file.CopyTo(path, @override);

        return path;
    }

    public static string PadName(this string name, int requestedLength = 8)
    {
        var retVal = name;

        if (!string.IsNullOrEmpty(name))
        {
            var dif = requestedLength - name.Length;

            if (dif > 0)
            {
                var tempName = new StringBuilder(name);

                for (var i = 0; i < dif; i++)
                {
                    tempName.Insert(0, '0');
                }

                retVal = tempName.ToString();
            }
        }

        return retVal;
    }
}
