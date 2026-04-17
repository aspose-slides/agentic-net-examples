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
        string outputPath = "output.swf";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Configure layout options to place comments on the right side
            Aspose.Slides.Export.NotesCommentsLayoutingOptions layoutOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
            layoutOptions.CommentsPosition = Aspose.Slides.Export.CommentsPositions.Right;

            // Set the layout options in Swf export options
            Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
            swfOptions.SlidesLayoutOptions = layoutOptions;

            // Save the presentation with the configured options
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

            // Dispose the presentation
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format exception
            // Format not supported
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}