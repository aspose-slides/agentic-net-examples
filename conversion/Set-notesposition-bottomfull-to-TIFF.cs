using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlidesToTiffWithNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.tiff";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Configure TIFF export options to include full speaker notes at the bottom
                TiffOptions tiffOptions = new TiffOptions();
                NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
                notesOptions.NotesPosition = NotesPositions.BottomFull;
                tiffOptions.SlidesLayoutOptions = notesOptions;

                // Save the presentation as a TIFF file with the specified options
                presentation.Save(outputPath, SaveFormat.Tiff, tiffOptions);

                // Dispose the presentation object
                presentation.Dispose();

                Console.WriteLine("Presentation successfully saved as TIFF with notes: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}