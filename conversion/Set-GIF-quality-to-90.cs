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

        // Verify that the source presentation exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // GifOptions does not expose a Quality property.
                // GIF quality is managed internally; you can adjust other parameters such as frame size or transition FPS if needed.
                GifOptions gifOptions = new GifOptions();

                // Save the presentation as an animated GIF with the specified options
                pres.Save(outputPath, SaveFormat.Gif, gifOptions);
            }
        }
        catch (NotSupportedException ex)
        {
            // Handle cases where the format is not supported
            Console.WriteLine("The requested format is not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}