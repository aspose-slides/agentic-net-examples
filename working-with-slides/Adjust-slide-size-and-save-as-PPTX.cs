using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            var presentation = new Aspose.Slides.Presentation(inputPath);

            // Set custom slide size with EnsureFit scaling
            presentation.SlideSize.SetSize(800f, 600f, Aspose.Slides.SlideSizeScaleType.EnsureFit);

            // Set slide size to A4 paper with Maximize scaling
            presentation.SlideSize.SetSize(Aspose.Slides.SlideSizeType.A4Paper, Aspose.Slides.SlideSizeScaleType.Maximize);

            // Save the modified presentation as PPTX
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}