using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.swf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Retrieve original slide dimensions
            float slideWidth = presentation.SlideSize.Size.Width;
            float slideHeight = presentation.SlideSize.Size.Height;

            // The stage size will match the original slide size automatically.
            // Create SWF options (customize as needed)
            Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
            swfOptions.ViewerIncluded = true; // include viewer

            // Save the presentation as SWF using the options
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

            // Ensure the presentation is saved before exiting (optional copy)
            presentation.Save("temp.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            presentation.Dispose();
            Console.WriteLine("Conversion to SWF completed successfully.");
        }
        catch (NotSupportedException ex)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}