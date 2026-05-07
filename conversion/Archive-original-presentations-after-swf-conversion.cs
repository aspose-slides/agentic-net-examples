using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfConversionAndArchive
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define paths
            string inputPath = @"C:\Presentations\example.pptx";
            string outputDirectory = @"C:\Presentations\Converted";
            string archiveDirectory = @"C:\Presentations\Archive";

            // Ensure output and archive directories exist
            Directory.CreateDirectory(outputDirectory);
            Directory.CreateDirectory(archiveDirectory);

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Presentation presentation = new Presentation(inputPath);

                // Prepare SWF options (default settings)
                SwfOptions swfOptions = new SwfOptions();

                // Define output SWF file path
                string outputSwfPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".swf");

                // Save as SWF
                presentation.Save(outputSwfPath, SaveFormat.Swf, swfOptions);

                // Archive original presentation
                string archivedPath = Path.Combine(archiveDirectory, Path.GetFileName(inputPath));
                // Overwrite if already exists in archive
                if (File.Exists(archivedPath))
                {
                    File.Delete(archivedPath);
                }
                File.Move(inputPath, archivedPath);

                // Dispose presentation
                presentation.Dispose();

                Console.WriteLine("Conversion successful. Original file archived.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported for SWF conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}