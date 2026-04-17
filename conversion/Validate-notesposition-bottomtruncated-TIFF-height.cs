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
            Presentation presentation = new Presentation(inputPath);

            // Configure notes layout to BottomTruncated to limit note height
            NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
            notesOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomTruncated;

            // Set TIFF export options with the notes layout
            TiffOptions tiffOptions = new TiffOptions();
            tiffOptions.SlidesLayoutOptions = notesOptions;

            // Save the presentation as TIFF using the configured options
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);

            // Dispose the presentation object
            presentation.Dispose();

            Console.WriteLine("TIFF file saved successfully to: " + outputPath);
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The specified format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URL issues)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}