using System.Reflection;

Console.WriteLine("Please, specify the path to the root folder:");

var rootDirectory = Console.ReadLine();

var entities = Directory.GetFileSystemEntries(rootDirectory, "*",
    enumerationOptions: new EnumerationOptions { MaxRecursionDepth = 2, RecurseSubdirectories = true });

Console.WriteLine(entities.Count());

foreach (var entity in entities)
    Console.WriteLine(entity);

Console.ReadKey();