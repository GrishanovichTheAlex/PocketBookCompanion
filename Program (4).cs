//using Core;
//using System.IO.Compression;

//var inputPath = @"D:\_ToEdit\(C84) [Tanmatsu Ijou (BadHanD)] Souko no Tobari";// Console.ReadLine();
//var outputPath = @"D:\Test";

//if (Directory.Exists(inputPath))
//{
//    var dirInfo = new DirectoryInfo(inputPath);

//    var files = dirInfo.GetFiles();

//    if (files.All(f => FileExtensionHelper.IsImage(f)))
//    {
//        if (Directory.Exists(outputPath))
//        {
//            try
//            {
//                var a = inputPath.GetFolderName(); 
                
//                files.First().

//                ZipFile.CreateFromDirectory(inputPath, Path.Combine(outputPath, inputPath.GetFolderName() + ".zip"));
//            }
//            catch (UnauthorizedAccessException ex)
//            {
//                //todo
//            }
//        }
//    }
//}