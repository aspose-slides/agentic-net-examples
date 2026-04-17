using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.tiff";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Configure TIFF export options without notes
            TiffOptions options = new TiffOptions();
            NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
            notesOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.None;
            options.SlidesLayoutOptions = notesOptions;

            // Save the presentation as TIFF
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, options);

            // Dispose the presentation
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}