using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
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
            using (Presentation pres = new Presentation(inputPath))
            {
                // Configure TIFF options with notes layout set to BottomTruncated
                TiffOptions tiffOptions = new TiffOptions();
                NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
                notesOptions.NotesPosition = NotesPositions.BottomTruncated;
                tiffOptions.SlidesLayoutOptions = notesOptions;

                // Save the presentation as TIFF using the configured options
                pres.Save(outputPath, SaveFormat.Tiff, tiffOptions);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URL or web service errors)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}