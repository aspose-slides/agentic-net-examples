using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.gif";

        // Verify that the input file exists
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
                // Initialize GIF export options
                // Note: GifOptions does not expose a Quality property; GIF quality is managed via other settings.
                GifOptions gifOptions = new GifOptions();

                // Example of other configurable options (optional)
                // gifOptions.FrameSize = new System.Drawing.Size(960, 720);
                // gifOptions.TransitionFps = 35;

                // Save the presentation as an animated GIF
                presentation.Save(outputPath, SaveFormat.Gif, gifOptions);
            }
        }
        catch (NotSupportedException ex)
        {
            // Handle unsupported format scenario
            Console.WriteLine("Format not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}