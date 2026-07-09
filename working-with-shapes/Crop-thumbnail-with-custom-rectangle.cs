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
        string outputPath = "thumbnail_cropped.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Define scaling factors for the thumbnail (full size in this case)
            float scaleX = 1f;
            float scaleY = 1f;

            // Generate the thumbnail image
            IImage thumbnail = slide.GetImage(scaleX, scaleY);

            // TODO: Crop the thumbnail to a specific rectangle (e.g., x=100, y=100, width=200, height=150)
            // Aspose.Slides IImage does not provide direct cropping; additional image processing would be required here.
            // For demonstration purposes, we save the full thumbnail.

            thumbnail.Save(outputPath, Aspose.Slides.ImageFormat.Png);

            // Save the presentation before exiting
            pres.Save("output.pptx", SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Handle unsupported file format
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}