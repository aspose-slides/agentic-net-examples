using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideConverter
{
    class Program
    {
        // Network folders (adjust paths as needed)
        private static readonly string inputFolder = @"\\network\share\input";
        private static readonly string outputFolder = @"\\network\share\output";
        private static readonly string archiveFolder = @"\\network\share\archive";

        static void Main(string[] args)
        {
            // Ensure required directories exist
            if (!Directory.Exists(inputFolder))
            {
                Console.WriteLine("Input folder does not exist: " + inputFolder);
                return;
            }
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }
            if (!Directory.Exists(archiveFolder))
            {
                Directory.CreateDirectory(archiveFolder);
            }

            // Set up watcher for PPTX files
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = inputFolder;
            watcher.Filter = "*.pptx";
            watcher.Created += OnCreated;
            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Monitoring folder: " + inputFolder);
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine(); // Keep the application running
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            // Wait briefly to ensure the file is fully written
            System.Threading.Thread.Sleep(500);

            if (!File.Exists(e.FullPath))
            {
                // File does not exist, nothing to process
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(e.FullPath);

                // Set XPS conversion options
                XpsOptions xpsOptions = new XpsOptions();
                xpsOptions.SaveMetafilesAsPng = true; // Example option

                // Determine output XPS file path
                string xpsFileName = Path.GetFileNameWithoutExtension(e.Name) + ".xps";
                string xpsOutputPath = Path.Combine(outputFolder, xpsFileName);

                // Save as XPS
                pres.Save(xpsOutputPath, SaveFormat.Xps, xpsOptions);

                // Save presentation before exit (already saved)
                pres.Dispose();

                // Move original PPTX to archive folder
                string archivePath = Path.Combine(archiveFolder, e.Name);
                File.Move(e.FullPath, archivePath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The file format is not supported for conversion.
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., network errors)
                Console.WriteLine("Error processing file '" + e.Name + "': " + ex.Message);
            }
        }
    }
}