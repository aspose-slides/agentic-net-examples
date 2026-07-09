using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace ReplaceRectangles
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect input and output file paths as arguments
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: ReplaceRectangles <input.pptx> <output.pptx>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Iterate through slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    // Process even-numbered slides (slide numbers start at 1)
                    if ((slideIndex + 1) % 2 == 0)
                    {
                        Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                        Aspose.Slides.IShapeCollection shapes = slide.Shapes;

                        // Iterate through shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < shapes.Count; shapeIndex++)
                        {
                            Aspose.Slides.IShape shape = shapes[shapeIndex];

                            // Cast to GeometryShape to access ShapeType
                            Aspose.Slides.GeometryShape geometryShape = shape as Aspose.Slides.GeometryShape;
                            if (geometryShape != null && geometryShape.ShapeType == Aspose.Slides.ShapeType.Rectangle)
                            {
                                // Preserve existing fill color (if any)
                                Color originalColor = Color.Empty;
                                if (geometryShape.FillFormat != null && geometryShape.FillFormat.FillType == Aspose.Slides.FillType.Solid)
                                {
                                    originalColor = geometryShape.FillFormat.SolidFillColor.Color;
                                }

                                // Change shape to rounded rectangle
                                geometryShape.ShapeType = Aspose.Slides.ShapeType.RoundCornerRectangle;

                                // Reapply fill color
                                if (geometryShape.FillFormat != null)
                                {
                                    geometryShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                                    if (originalColor != Color.Empty)
                                    {
                                        geometryShape.FillFormat.SolidFillColor.Color = originalColor;
                                    }
                                }
                            }
                        }
                    }
                }

                // Ensure output directory exists
                string outputDir = Path.GetDirectoryName(Path.GetFullPath(outputPath));
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}