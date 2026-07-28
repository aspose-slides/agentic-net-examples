// -----------------------------------------------------------------------------
// Example: Validate decorative flags on all slides using C#
//
// Description:
// Demonstrates how to iterate through all slides and shapes in a PowerPoint
// presentation, check each shape's IsDecorative flag, report non‑decorative
// shapes, and save the presentation using Aspose.Slides for .NET. This example
// is a standalone console application suitable for automating validation of
// decorative markings in PPTX files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, Decorative, Flags,
// Shape, Slide, IsDecorative, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate validation of decorative flags on shapes across all slides.
// - Build C# tools for checking accessibility‑related properties in PowerPoint.
// - Integrate shape property validation into .NET presentation workflows.
// - Ensure presentations meet decorative‑shape requirements before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                        bool isDecorative = shape.IsDecorative;
                        if (!isDecorative)
                        {
                            Console.WriteLine($"Shape {shapeIndex} on slide {slideIndex} is not marked as decorative.");
                        }
                    }
                }

                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
