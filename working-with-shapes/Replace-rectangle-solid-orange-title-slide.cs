using System;
using System.IO;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Assume the title slide is the first slide (index 0)
            Aspose.Slides.ISlide titleSlide = presentation.Slides[0];

            // Iterate through all shapes on the title slide
            foreach (Aspose.Slides.IShape shape in titleSlide.Shapes)
            {
                // Process only rectangle AutoShapes
                Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                if (autoShape != null && autoShape.ShapeType == Aspose.Slides.ShapeType.Rectangle)
                {
                    // Set solid fill type
                    autoShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;

                    // Apply solid orange color (RGB 255,165,0) while preserving borders
                    autoShape.FillFormat.SolidFillColor.Color = Color.FromArgb(255, 165, 0);
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // If the exception is due to an unsupported format, indicate that the format is not supported
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}