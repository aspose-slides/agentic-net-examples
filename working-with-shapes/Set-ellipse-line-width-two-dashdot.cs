using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input file (if any)
            string inputPath = args.Length > 0 ? args[0] : null;
            Presentation presentation = null;

            if (!string.IsNullOrEmpty(inputPath))
            {
                // Check if the file exists
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine("File not found: " + inputPath);
                    return;
                }

                try
                {
                    // Load the presentation
                    presentation = new Presentation(inputPath);
                }
                catch (Exception)
                {
                    // Format not supported
                    Console.WriteLine("The file format is not supported or the file is corrupted.");
                    return;
                }
            }
            else
            {
                // Create a new presentation if no input file is provided
                presentation = new Presentation();
                // (Optional) Add a sample ellipse for demonstration
                ISlide firstSlide = presentation.Slides[0];
                firstSlide.Shapes.AddAutoShape(ShapeType.Ellipse, 50f, 50f, 150f, 100f);
            }

            // Iterate through all slides and shapes
            foreach (ISlide slide in presentation.Slides)
            {
                foreach (IShape shape in slide.Shapes)
                {
                    // Check if the shape is a geometry shape and of type Ellipse
                    if (shape is GeometryShape geometryShape && geometryShape.ShapeType == ShapeType.Ellipse)
                    {
                        // Ensure the shape has a line format
                        if (shape.LineFormat != null)
                        {
                            // Set line width to 2 points
                            shape.LineFormat.Width = 2f;
                            // Set dash style to DashDot
                            shape.LineFormat.DashStyle = LineDashStyle.DashDot;
                        }
                    }
                }
            }

            // Save the presentation
            string outputPath = "output.pptx";
            try
            {
                presentation.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
            finally
            {
                // Dispose the presentation object
                presentation.Dispose();
            }
        }
    }
}