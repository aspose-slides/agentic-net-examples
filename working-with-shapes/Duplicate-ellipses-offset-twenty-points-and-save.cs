using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CloneEllipses
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through each slide
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        ISlide slide = pres.Slides[slideIndex];
                        IShapeCollection shapes = slide.Shapes;

                        // Iterate through each shape on the slide
                        for (int shapeIndex = 0; shapeIndex < shapes.Count; shapeIndex++)
                        {
                            IShape shape = shapes[shapeIndex];

                            // Check if the shape is an ellipse
                            if (shape is IAutoShape)
                            {
                                IAutoShape autoShape = (IAutoShape)shape;
                                if (autoShape.ShapeType == ShapeType.Ellipse)
                                {
                                    // Calculate new position offset by 20 points
                                    float newX = autoShape.X + 20f;
                                    float newY = autoShape.Y + 20f;

                                    // Clone the ellipse with the new position
                                    shapes.AddClone(autoShape, newX, newY);
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}