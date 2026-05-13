using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        Presentation pres = null;
        try
        {
            // Load existing presentation if it exists, otherwise create a new one
            if (File.Exists(inputPath))
            {
                pres = new Presentation(inputPath);
            }
            else
            {
                pres = new Presentation();
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or loading errors
            Console.WriteLine("Error loading presentation: " + ex.Message);
            return;
        }

        // Add ten plain line shapes to each slide with incremental Y offset
        for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
        {
            ISlide slide = pres.Slides[slideIndex];
            for (int i = 0; i < 10; i++)
            {
                float yOffset = 50 + i * 20; // Incremental Y coordinate
                // Add a plain line shape
                IAutoShape line = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 50, yOffset, 300, 0);
                // Set line width (optional)
                line.LineFormat.Width = 2;
            }
        }

        try
        {
            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle save errors (e.g., unsupported format)
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
        finally
        {
            // Dispose the presentation
            pres.Dispose();
        }
    }
}