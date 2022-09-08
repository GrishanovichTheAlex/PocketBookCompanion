using Core;
using Core.Helpers;
using System.IO.Compression;
using System.Reflection;

Console.WriteLine("Please, specify the path to the root folder:");

var rootDirectory = @"D:\New folder (4)\New folder\Akazawa RED"; //Console.ReadLine();
var testOutput = @"C:\Users\grish\OneDrive\Desktop\Test";
var i = 0;

var dirs = Directory.GetDirectories(rootDirectory);

var files = Directory.GetFiles(rootDirectory)
    .Select(filePath => new FileInfo(filePath))
    .OrderBy(p => p.Name, new AlpabethicalComparer());

foreach (var file in files)
{
    if (file.IsArchive())
    {
        var archive = ZipFile.Open(file.FullName, ZipArchiveMode.Read);

        foreach (var archivedFile in archive.Entries)
        {
            var fileExtension = archivedFile.Name.GetFileExtension();

            archivedFile.ExtractToFile(Path.Combine(testOutput, $"{(i++).ToString().PadName()}{fileExtension}"), true);
        }
    }
}





var entities = Directory.GetFileSystemEntries(rootDirectory, "*",
    enumerationOptions: new EnumerationOptions { MaxRecursionDepth = 2, RecurseSubdirectories = true });

Console.WriteLine(entities.Count());

foreach (var entity in entities)
    Console.WriteLine(entity);

Console.ReadKey();

