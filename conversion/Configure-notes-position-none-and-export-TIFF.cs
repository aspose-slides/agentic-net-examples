using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesTiffExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define data directory
            string dataDir = Path.Combine(Environment.CurrentDirectory, "Data");
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Input and output file paths
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output.tiff");

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Configure TIFF options to exclude notes
                TiffOptions options = new TiffOptions();
                NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
                notesOptions.NotesPosition = NotesPositions.None; // Exclude notes
                options.SlidesLayoutOptions = notesOptions;

                try
                {
                    // Save presentation as TIFF without notes
                    pres.Save(outputPath, SaveFormat.Tiff, options);
                }
                catch (Exception ex)
                {
                    // Handle format not supported or other saving errors
                    // Format not supported
                    Console.WriteLine("Error saving TIFF: " + ex.Message);
                }
            }

            // Presentation saved before exit
            Console.WriteLine("TIFF image generated at: " + outputPath);
        }
    }
}