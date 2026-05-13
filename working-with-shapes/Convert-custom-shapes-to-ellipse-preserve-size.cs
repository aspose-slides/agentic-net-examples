using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Determine input file path
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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate over each slide
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                // Iterate over shapes in reverse order to allow removal
                for (int shapeIndex = slide.Shapes.Count - 1; shapeIndex >= 0; shapeIndex--)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                    // Identify custom geometry shapes
                    Aspose.Slides.GeometryShape geometryShape = shape as Aspose.Slides.GeometryShape;
                    if (geometryShape != null && geometryShape.ShapeType == Aspose.Slides.ShapeType.Custom)
                    {
                        // Preserve position and size
                        float x = geometryShape.X;
                        float y = geometryShape.Y;
                        float width = geometryShape.Width;
                        float height = geometryShape.Height;

                        // Remove the custom shape
                        slide.Shapes.Remove(geometryShape);

                        // Add an ellipse with the same dimensions
                        slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, x, y, width, height);
                    }
                }
            }

            // Ensure the output directory exists
            string outputDir = "output";
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Save the modified presentation
            string outputPath = Path.Combine(outputDir, "converted.pptx");
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Aspose.Slides.PptUnsupportedFormatException)
        {
            // Format not supported
            Console.WriteLine("The presentation format is not supported.");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}