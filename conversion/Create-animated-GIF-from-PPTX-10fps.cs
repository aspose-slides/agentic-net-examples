using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output paths
        string inputPath = "input.pptx";
        string outputPath = "output.gif";

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

            // Configure GIF export options with custom frame rate
            Aspose.Slides.Export.GifOptions gifOptions = new Aspose.Slides.Export.GifOptions();
            gifOptions.TransitionFps = 10; // Set frame rate to 10 FPS

            // Save the presentation as an animated GIF
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Gif, gifOptions);

            // Dispose the presentation object
            presentation.Dispose();

            Console.WriteLine("Animated GIF created successfully.");
        }
        catch (NotSupportedException)
        {
            // Handle unsupported format exception
            Console.WriteLine("The file format is not supported for GIF conversion.");
        }
        catch (Exception ex)
        {
            // Handle other possible exceptions
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}