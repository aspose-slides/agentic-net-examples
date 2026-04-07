using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input presentation path and output folder
        var inputPath = "input.pptx";
        var outputFolder = "OutputImages";
        var outputPresentationPath = "output.pptx";

        // Check if input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            var presentation = new Aspose.Slides.Presentation(inputPath);

            // Set custom slide size (e.g., 800x600 points) without scaling existing content
            presentation.SlideSize.SetSize(800f, 600f, Aspose.Slides.SlideSizeScaleType.DoNotScale);

            // Ensure output directory exists
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Export each slide as JPEG image
            for (var i = 0; i < presentation.Slides.Count; i++)
            {
                var slide = presentation.Slides[i];
                using (var image = slide.GetImage(1f, 1f))
                {
                    var imagePath = Path.Combine(outputFolder, $"Slide_{i + 1}.jpg");
                    image.Save(imagePath, Aspose.Slides.ImageFormat.Jpeg);
                }
            }

            // Save the modified presentation
            presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., file I/O, Aspose errors)
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}