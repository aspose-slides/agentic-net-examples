using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToTiffWithNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path
            string inputPath = "input.pptx";
            // Output TIFF file path
            string outputPath = "output.tiff";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Presentation pres = new Presentation(inputPath);

                // Configure TIFF options with notes embedded
                TiffOptions options = new TiffOptions();
                NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
                notesOptions.NotesPosition = NotesPositions.BottomFull;
                options.SlidesLayoutOptions = notesOptions;

                // Save as TIFF with the specified options
                pres.Save(outputPath, SaveFormat.Tiff, options);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}