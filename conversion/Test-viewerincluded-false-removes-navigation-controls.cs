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
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Configure SWF options to exclude the integrated viewer
                SwfOptions swfOptions = new SwfOptions();
                swfOptions.ViewerIncluded = false;

                // Save presentation as SWF without viewer
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.swf");
                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

                // Optionally, save another SWF with the viewer included for comparison
                swfOptions.ViewerIncluded = true;
                string outputPathWithViewer = Path.Combine(Directory.GetCurrentDirectory(), "output_with_viewer.swf");
                presentation.Save(outputPathWithViewer, SaveFormat.Swf, swfOptions);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions (e.g., external URL issues)
        }
    }
}