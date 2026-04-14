using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ShapeThumbnailExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define file paths
            string inputPath = "input.pptx";
            string outputPptx = "output.pptx";
            string outputPng = "shape_thumb.png";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load presentation
            Aspose.Slides.Presentation pres = null;
            try
            {
                pres = new Aspose.Slides.Presentation(inputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // Access first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Attempt to find a shape with a specific ID (example ID: 9999)
            Aspose.Slides.IShape targetShape = null;
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape.OfficeInteropShapeId == 9999)
                {
                    targetShape = shape;
                    break;
                }
            }

            // If shape not found, create a new rectangle shape (using the provided rule)
            if (targetShape == null)
            {
                // Create a rectangle shape
                Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle,
                    100,   // X position
                    100,   // Y position
                    200,   // Width
                    100    // Height
                );
                shape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
                shape.LineFormat.SketchFormat.SketchType = Aspose.Slides.LineSketchType.Scribble;
                targetShape = shape;
            }

            // Generate thumbnail for the shape
            Aspose.Slides.IImage shapeImage = null;
            try
            {
                shapeImage = targetShape.GetImage(
                    Aspose.Slides.ShapeThumbnailBounds.Shape,
                    1f,    // scaleX
                    1f     // scaleY
                );
                shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error generating shape thumbnail: " + ex.Message);
            }

            // Save the presentation
            try
            {
                pres.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }

            // Dispose resources
            pres.Dispose();
        }
    }
}