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
            string inputPath = "input.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Iterate over all slides
                    foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                    {
                        // Get the shapes collection of the slide
                        Aspose.Slides.IShapeCollection shapes = slide.Shapes;

                        // Iterate over each shape
                        foreach (Aspose.Slides.IShape shape in shapes)
                        {
                            // Cast to GeometryShape to access ShapeType and LineFormat
                            Aspose.Slides.GeometryShape geometryShape = shape as Aspose.Slides.GeometryShape;

                            if (geometryShape != null && geometryShape.ShapeType == Aspose.Slides.ShapeType.Ellipse)
                            {
                                // Change the line width to 2 points
                                Aspose.Slides.ILineFormat lineFormat = geometryShape.LineFormat;
                                if (lineFormat != null)
                                {
                                    lineFormat.Width = 2f;
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    string outputPath = "output.pptx";
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}