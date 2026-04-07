using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Enable viewer UI in the generated SWF
            Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
            swfOptions.ViewerIncluded = true;

            // Enable navigation controls (media controls) for slide show
            presentation.SlideShowSettings.ShowMediaControls = true;

            // Save as SWF with the specified options
            string swfOutputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.swf");
            presentation.Save(swfOutputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

            // Save the presentation before exiting (optional)
            string pptxOutputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
            presentation.Save(pptxOutputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            presentation.Dispose();

            Console.WriteLine("SWF saved to: " + swfOutputPath);
            Console.WriteLine("Presentation saved to: " + pptxOutputPath);
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported for SWF conversion.");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}