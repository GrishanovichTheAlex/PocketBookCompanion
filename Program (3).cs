//using PocketBookCompanion;
//using System.Globalization;
//using System.IO.Compression;
//using System.Reflection;

//Console.WriteLine(CultureInfo.CurrentCulture);

//CultureInfo.CurrentCulture = new CultureInfo("ru-RU");
//CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("ru-RU");

//Console.WriteLine("Please, specify the path to the root folder:");

//var rootDirectory = @"C:\[Workspace]\Temp";// Console.ReadLine();

//var entities = Directory.GetFileSystemEntries(rootDirectory, "*.txt", SearchOption.AllDirectories)
//    .OrderBy(e => e, new AlpabethicalComparer());

//foreach (var entity in entities)
//    Console.WriteLine(entity);

//Console.WriteLine(entities.Count());

//var zip = entities.First();

//using var zipArchive = ZipFile.Open(zip, ZipArchiveMode.Update);

//var entry = zipArchive.CreateEntryFromFile(@"C:\Users\grish\Downloads\New folder\86446c2094c6cff7f5efe761626cdf51.gif", "1.gif");

////zipArchive.ExtractToDirectory(@"C:\[Workspace]\Temp\New folder");

//var a = entry.Open();

