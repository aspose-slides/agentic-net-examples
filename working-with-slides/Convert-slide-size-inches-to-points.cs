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
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Custom slide size in inches
        float widthInches = 10.0f;
        float heightInches = 7.5f;

        // Convert inches to points (1 inch = 72 points)
        float widthPoints = widthInches * 72f;
        float heightPoints = heightInches * 72f;

        // Set the custom slide size with content scaling to ensure fit
        presentation.SlideSize.SetSize(widthPoints, heightPoints, Aspose.Slides.SlideSizeScaleType.EnsureFit);

        // Save the modified presentation
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Format not supported or other save error
            Console.WriteLine("Failed to save presentation: " + ex.Message);
        }

        // Clean up
        presentation.Dispose();
    }
}