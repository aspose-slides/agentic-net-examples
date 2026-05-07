using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        var inputPath = "input.pptx";
        var outputPath = "output.swf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            var presentation = new Aspose.Slides.Presentation(inputPath);

            // Configure SWF options to exclude hidden slides
            var swfOptions = new Aspose.Slides.Export.SwfOptions();
            swfOptions.ShowHiddenSlides = false;

            // Convert and save as SWF
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}