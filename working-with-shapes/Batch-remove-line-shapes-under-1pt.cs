// -----------------------------------------------------------------------------
// Example: Batch Remove Line Shapes Under 1pt Using C#
// 
// Description:
// Demonstrates how to create a sample PPTX if none exists, then iterate through
// all slides and remove line shapes whose line width is less than 1 point.
// Uses Aspose.Slides for .NET to manipulate PowerPoint files in a console
// application and saves the cleaned presentation.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, batch remove thin lines, shape processing
// 
// Use Cases:
// - Clean up presentations by removing unintentionally thin line drawings.
// - Automate preprocessing of PPTX files before publishing or conversion.
// - Integrate thin‑line removal into larger .NET presentation‑processing pipelines.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace RemoveThinLines
{
    class Program
    {
        static int Main(string[] args)
        {
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = args.Length > 1 ? args[1] : "output.pptx";

            // Create a sample presentation if the input file does not exist
            if (!File.Exists(inputPath))
            {
                try
                {
                    Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                    Aspose.Slides.ISlide sampleSlide = samplePres.Slides[0];

                    // Thin line (0.5 pt) – should be removed
                    Aspose.Slides.IShape thinLine = sampleSlide.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Line, 50, 50, 200, 0);
                    thinLine.LineFormat.Width = 0.5f;

                    // Thick line (2 pt) – should remain
                    Aspose.Slides.IShape thickLine = sampleSlide.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Line, 50, 100, 200, 0);
                    thickLine.LineFormat.Width = 2.0f;

                    samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    samplePres.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to create sample input: " + ex.Message);
                    return 1;
                }
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load presentation. The file format may not be supported.");
                return 1;
            }

            for (int slideIdx = 0; slideIdx < presentation.Slides.Count; slideIdx++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIdx];
                for (int shapeIdx = slide.Shapes.Count - 1; shapeIdx >= 0; shapeIdx--)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIdx];
                    if (shape.LineFormat != null && shape.LineFormat.Width < 1.0f)
                    {
                        slide.Shapes.Remove(shape);
                    }
                }
            }

            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
                return 1;
            }
            finally
            {
                presentation.Dispose();
            }

            Console.WriteLine("Processing completed. Output saved to " + outputPath);
            return 0;
        }
    }
}
