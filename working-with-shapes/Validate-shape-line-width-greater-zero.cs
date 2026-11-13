// -----------------------------------------------------------------------------
// Example: Validate and Correct Shape Line Width Greater Than Zero in PPTX
//
// Description:
// This console program loads a PowerPoint presentation, checks every shape on
// each slide to ensure its outline line width is greater than zero, and sets a
// minimal positive width where needed. It creates a sample presentation if the
// input file is missing, then saves the corrected file.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, shape line width validation
//
// Use Cases:
// - Enforce visual consistency by preventing invisible shape outlines.
// - Automate design guideline compliance checks in PPTX files.
// - Prepare presentations for publishing where zero-width lines are disallowed.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------

using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Create a sample presentation if the input file does not exist
        if (!File.Exists(inputPath))
        {
            try
            {
                Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide firstSlide = samplePres.Slides[0];
                Aspose.Slides.IShape rectShape = firstSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);
                // Set line width to zero to simulate the issue
                rectShape.LineFormat.Width = 0.0f;
                samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                samplePres.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create sample input file: " + ex.Message);
                Environment.Exit(1);
            }
        }

        // Verify that the input file now exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            Environment.Exit(1);
        }

        try
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            for (int slideIdx = 0; slideIdx < pres.Slides.Count; slideIdx++)
            {
                Aspose.Slides.ISlide slide = pres.Slides[slideIdx];
                for (int shapeIdx = 0; shapeIdx < slide.Shapes.Count; shapeIdx++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIdx];
                    Aspose.Slides.ILineFormat lineFmt = shape.LineFormat;
                    if (lineFmt != null && lineFmt.Width <= 0)
                    {
                        lineFmt.Width = 0.5f; // Set minimal positive line width
                    }
                }
            }

            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The presentation format is not supported.");
            Environment.Exit(1);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            Environment.Exit(1);
        }

        Console.WriteLine("Shape line widths validated and corrected. Output saved to " + outputPath);
        Environment.Exit(0);
    }
}
