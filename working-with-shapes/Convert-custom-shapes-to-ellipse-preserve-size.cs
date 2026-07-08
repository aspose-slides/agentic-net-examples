using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate over all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                    Aspose.Slides.IShapeCollection shapes = slide.Shapes;

                    // Iterate over shapes using index to allow removal/replacement
                    for (int shapeIndex = 0; shapeIndex < shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = shapes[shapeIndex];

                        // Cast to GeometryShape to access ShapeType and geometry properties
                        Aspose.Slides.GeometryShape geometryShape = shape as Aspose.Slides.GeometryShape;

                        // If the shape is a geometry shape and not already an ellipse, convert it
                        if (geometryShape != null && geometryShape.ShapeType != Aspose.Slides.ShapeType.Ellipse)
                        {
                            // Preserve position and size
                            float x = geometryShape.X;
                            float y = geometryShape.Y;
                            float width = geometryShape.Width;
                            float height = geometryShape.Height;

                            // Remove the original shape
                            shapes.RemoveAt(shapeIndex);

                            // Insert a new ellipse at the same position
                            Aspose.Slides.IAutoShape ellipse = shapes.InsertAutoShape(
                                shapeIndex,
                                Aspose.Slides.ShapeType.Ellipse,
                                x,
                                y,
                                width,
                                height);

                            // No need to adjust the index because we replaced at the same position
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Handle unsupported file format
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}