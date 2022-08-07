//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO.Compression;

//namespace Renamer
//{
//    public class Worker
//    {
//        private readonly FilteTypes _fileTypes;

//        private int i = 0;

//        public Worker()
//        {
//            _fileTypes = new FilteTypes();
//        }

//        public void Run(string[] args)
//        {
//            Console.WriteLine("from:");
//            var from = Console.ReadLine();

//            Console.WriteLine("to:");
//            //var to = Console.ReadLine();

//            //var from = @"\\KEENETIC-7659\Media\[Manga]\Не сдавайся!";
//            var to = @"C:\Users\grish\Desktop";
//            //var to = @"F:\";

//            if (Directory.Exists(from) && Directory.Exists(to))
//            {
//                Run(from, to);
//            }
//            else
//            {
//                throw new Exception("Wrong input.");
//            }
//        }

//        private void Run(string from, string to)
//        {
//            var dirInfo = new DirectoryInfo(from);

//            if (!dirInfo.GetDirectories().Any() &&
//                dirInfo.GetFiles().Any() &&
//                dirInfo.GetFiles().All(f => _fileTypes.IsPicture(f)))
//            {
//                MakeArchiveFromFolderWithPictures(from, to, dirInfo.Name);
//            }
//            else
//            {
//                var tempRootFolderPath = Path.Combine(to, $"_tmp");

//                if (!Directory.Exists(tempRootFolderPath))
//                {
//                    Directory.CreateDirectory(tempRootFolderPath);
//                }

//                var j = 0;

//                var files = dirInfo.EnumerateFiles()
//                    .OrderBy(d => d.Name, new NaturalStringComparer());

//                foreach (var file in files)
//                {
//                    if (_fileTypes.IsArchive(file))
//                    {
//                        var tempFolderWithExtractedFiles = ExtractFiles(file, tempRootFolderPath, j);

//                        SetFileNameToFilesInsideAndMove(tempFolderWithExtractedFiles, tempRootFolderPath);

//                        tempFolderWithExtractedFiles.Delete(true);
//                    }
//                }

//                MakeArchiveFromFolderWithPictures(tempRootFolderPath, to, dirInfo.Name);

//                if (Directory.Exists(tempRootFolderPath))
//                {
//                    Directory.Delete(tempRootFolderPath, true);
//                }
//            }
//        }

//        private void SetFileNameToFilesInsideAndMove(DirectoryInfo folder, string destinationFolder)
//        {
//            var files = folder.EnumerateFiles()
//                .OrderBy(f => f.Name);

//            if (files.Any())
//            {
//                foreach (var file in files)
//                {
//                    var path = Path.Combine(destinationFolder,
//                        $"{(++i).ToString("d5")}{file.Extension}");

//                    file.CopyTo(path, true);
//                }
//            }
//            else if (folder.GetDirectories().Length == 1)
//            {
//                SetFileNameToFilesInsideAndMove(folder.GetDirectories().Single(), destinationFolder);
//            }
//        }

//        private void SetFileNameToFilesInsideAndMove(DirectoryInfo folder, DirectoryInfo destinationFolder)
//        {
//            SetFileNameToFilesInsideAndMove(folder, destinationFolder.FullName);
//        }

//        private DirectoryInfo ExtractFiles(FileInfo archiveToExtract, string destinationFolder, int j)
//        {
//            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(archiveToExtract.FullName);
//            var newFolderName = Path.Combine(destinationFolder, j.ToString("d3"));

//            ZipFile.ExtractToDirectory(archiveToExtract.FullName, newFolderName, true);

//            return new DirectoryInfo(newFolderName);
//        }

//        private void MakeArchiveFromFolderWithPictures(string from, string to,
//            string archiveName, string extension = ".cbz", bool openFileDestinationFolder = true)
//        {
//            var newFilePath = Path.Combine(to, $"{archiveName}{extension}");

//            ZipFile.CreateFromDirectory(from, newFilePath, CompressionLevel.NoCompression, false);

//            //if (openFileDestinationFolder)
//            //{
//            //    OpenFolderInExplorer(newFilePath);
//            //}
//        }

//        private void OpenFolderInExplorer(string filePath)
//        {
//            if (!File.Exists(filePath))
//            {
//                return;
//            }

//            string argument = "/select, \"" + filePath + "\"";

//            System.Diagnostics.Process.Start("explorer.exe", argument);
//        }
//    }
//}
