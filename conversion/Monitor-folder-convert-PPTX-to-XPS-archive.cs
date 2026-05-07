using System;
using System.IO;
using System.Threading;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine the folder to monitor (network folder)
            string networkFolder;
            if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
            {
                networkFolder = args[0];
            }
            else
            {
                // Default path – adjust as needed
                networkFolder = @"\\NetworkShare\Presentations";
            }

            // Verify that the folder exists
            if (!Directory.Exists(networkFolder))
            {
                Console.WriteLine("The specified folder does not exist: " + networkFolder);
                return;
            }

            // Prepare the archive folder
            string archiveFolder = Path.Combine(networkFolder, "Archive");
            if (!Directory.Exists(archiveFolder))
            {
                Directory.CreateDirectory(archiveFolder);
            }

            // Set up a watcher for new PPTX files
            FileSystemWatcher watcher = new FileSystemWatcher(networkFolder, "*.pptx");
            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime;
            watcher.Created += (sender, e) => ProcessFile(e.FullPath, archiveFolder);
            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Monitoring folder: " + networkFolder);
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }

        private static void ProcessFile(string filePath, string archiveFolder)
        {
            // Wait until the file is ready for reading
            for (int attempt = 0; attempt < 10; attempt++)
            {
                try
                {
                    using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        // File is accessible
                        break;
                    }
                }
                catch (IOException)
                {
                    Thread.Sleep(500);
                }
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(filePath);

                // Prepare XPS options (customize if needed)
                XpsOptions xpsOptions = new XpsOptions();
                xpsOptions.SaveMetafilesAsPng = true;

                // Determine output XPS file path
                string xpsFileName = Path.GetFileNameWithoutExtension(filePath) + ".xps";
                string xpsFilePath = Path.Combine(Path.GetDirectoryName(filePath), xpsFileName);

                // Save as XPS
                presentation.Save(xpsFilePath, SaveFormat.Xps, xpsOptions);

                // Dispose the presentation (ensures resources are released)
                presentation.Dispose();

                // Move original PPTX to archive folder
                string destinationPath = Path.Combine(archiveFolder, Path.GetFileName(filePath));
                if (File.Exists(destinationPath))
                {
                    File.Delete(destinationPath);
                }
                File.Move(filePath, destinationPath);

                Console.WriteLine("Converted and archived: " + filePath);
            }
            catch (NotSupportedException)
            {
                // Format not supported – comment as required
                // The file format is not supported for conversion.
                Console.WriteLine("Unsupported format: " + filePath);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("Error processing file '" + filePath + "': " + ex.Message);
            }
        }
    }
}