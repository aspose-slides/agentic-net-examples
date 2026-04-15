using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertCustomShapes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input file path (first argument or default)
            string inputPath = "input.pptx";
            if (args.Length > 0)
            {
                inputPath = args[0];
            }

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through each slide
                    foreach (ISlide slide in presentation.Slides)
                    {
                        // Get the shape collection of the slide
                        IShapeCollection shapes = slide.Shapes;

                        // Iterate through each shape
                        foreach (IShape shape in shapes)
                        {
                            // Identify geometry shapes with a custom shape type
                            if (shape is IGeometryShape geometryShape && geometryShape.ShapeType == ShapeType.Custom)
                            {
                                // Change the shape type to Ellipse while preserving position and size
                                geometryShape.ShapeType = ShapeType.Ellipse;
                            }
                        }
                    }

                    // Save the modified presentation
                    string outputPath = "output.pptx";
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}