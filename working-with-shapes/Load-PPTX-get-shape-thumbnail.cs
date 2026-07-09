using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input PPTX file path
        string inputPath = "input.pptx";
        // Output thumbnail image path
        string outputPng = "shape_thumbnail.png";
        // Output PPTX path after processing
        string outputPptx = "output.pptx";
        // Shape ID to retrieve
        uint shapeId = 5; // example ID

        // Check if input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Find the shape with the specified ID
            Aspose.Slides.IShape targetShape = null;
            foreach (Aspose.Slides.ISlide slide in pres.Slides)
            {
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    if (shape.OfficeInteropShapeId == shapeId)
                    {
                        targetShape = shape;
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
                Console.WriteLine("Shape with ID " + shapeId + " not found.");
                pres.Dispose();
                return;
            }

            // Generate default thumbnail for the shape
            Aspose.Slides.IImage shapeImage = targetShape.GetImage();
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