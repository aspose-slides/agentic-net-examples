// -----------------------------------------------------------------------------
// Example: Convert Custom Shapes to Ellipse Preserving Size
//
// Description:
// Demonstrates how to convert custom geometry shapes to ellipses while preserving
// their original size and position using C# and Aspose.Slides for .NET. The program
// creates a sample PPTX if none is provided, processes the presentation, and saves
// the result.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Convert, Custom Shapes, Ellipse
//
// Use Cases:
// - Automate conversion of custom shapes to ellipses while preserving size.
// - Build C# tools for PowerPoint presentation processing.
// - Validate presentation workflows before publishing or integration.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        if (args.Length > 0)
        {
            inputPath = args[0];
        }

        if (!File.Exists(inputPath))
        {
            try
            {
                Aspose.Slides.Presentation samplePresentation = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide sampleSlide = samplePresentation.Slides[0];
                // Add a custom shape to demonstrate conversion
                sampleSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Custom, 100f, 100f, 200f, 100f);
                samplePresentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                samplePresentation.Dispose();
                Console.WriteLine("Sample input file created: " + inputPath);
            }
            catch (Exception createEx)
            {
                Console.WriteLine("Failed to create sample input file: " + createEx.Message);
                Environment.Exit(1);
                return;
            }
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                for (int shapeIndex = slide.Shapes.Count - 1; shapeIndex >= 0; shapeIndex--)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                    Aspose.Slides.GeometryShape geometryShape = shape as Aspose.Slides.GeometryShape;

                    if (geometryShape != null && geometryShape.ShapeType == Aspose.Slides.ShapeType.Custom)
                    {
                        float x = geometryShape.X;
                        float y = geometryShape.Y;
                        float width = geometryShape.Width;
                        float height = geometryShape.Height;

                        slide.Shapes.Remove(geometryShape);
                        slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, x, y, width, height);
                    }
                }
            }

            string outputDir = "output";
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            string outputPath = Path.Combine(outputDir, "converted.pptx");
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();

            Console.WriteLine("Conversion completed. Output saved to: " + outputPath);
        }
        catch (Aspose.Slides.PptUnsupportedFormatException)
        {
            Console.WriteLine("The presentation format is not supported.");
            Environment.Exit(1);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            Environment.Exit(1);
        }
    }
}
