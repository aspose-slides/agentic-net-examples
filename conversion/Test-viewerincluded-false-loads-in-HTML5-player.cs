using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input presentation path
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Create SWF options with ViewerIncluded set to false
                SwfOptions swfOptions = new SwfOptions();
                swfOptions.ViewerIncluded = false;

                // Save SWF without integrated viewer
                string outputSwfNoViewer = Path.Combine(Directory.GetCurrentDirectory(), "output_no_viewer.swf");
                presentation.Save(outputSwfNoViewer, SaveFormat.Swf, swfOptions);

                // Optionally, save SWF with integrated viewer for comparison
                swfOptions.ViewerIncluded = true;
                string outputSwfWithViewer = Path.Combine(Directory.GetCurrentDirectory(), "output_with_viewer.swf");
                presentation.Save(outputSwfWithViewer, SaveFormat.Swf, swfOptions);
            }
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}