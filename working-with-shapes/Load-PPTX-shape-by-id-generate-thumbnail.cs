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

        // Shape identifier to retrieve
        uint shapeId = 5; // replace with actual shape ID

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Locate the shape by its ID across all slides
            Shape targetShape = null;
            foreach (ISlide slide in pres.Slides)
            {
                foreach (IShape shape in slide.Shapes)
                {
                    if (shape is Shape && shape.OfficeInteropShapeId == shapeId)
                    {
                        targetShape = (Shape)shape;
                        break;
                    }
                }
                if (targetShape != null)
                {
                    break;
                }
            }

            if (targetShape == null)
            {
                Console.WriteLine("Shape with the specified ID was not found.");
                pres.Dispose();
                return;
            }

            // Generate the default thumbnail for the shape
            IImage shapeImage = targetShape.GetImage();
            shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);

            // Save the presentation before exiting
            pres.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}