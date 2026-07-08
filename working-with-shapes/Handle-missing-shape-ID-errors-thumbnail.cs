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
        string outputPptx = "output.pptx";
        string outputPng = "shape_thumbnail.png";

        // Shape identifier to look for
        uint targetShapeId = 5; // example ID

        // Verify input file existence
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Search for shape with the specified ID
            Aspose.Slides.IShape targetShape = null;
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape.OfficeInteropShapeId == targetShapeId)
                {
                    targetShape = shape;
                    break;
                }
            }

            // Handle missing shape
            if (targetShape == null)
            {
                Console.WriteLine("Shape with the specified ID was not found.");
                // Save presentation before exit as required
                pres.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);
                return;
            }

            // Generate thumbnail for the found shape
            Aspose.Slides.IImage shapeImage = targetShape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, 1f, 1f);
            shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);

            // Save the presentation
            pres.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URLs or web services)
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}