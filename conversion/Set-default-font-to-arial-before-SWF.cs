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

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Create SWF options and set the default regular font to Arial
            Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
            swfOptions.DefaultRegularFont = "Arial";

            // Save the presentation to SWF format
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

            // Dispose the presentation before exiting
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle format not supported or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}