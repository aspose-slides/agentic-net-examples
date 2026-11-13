// -----------------------------------------------------------------------------
// Example: Detect and Replace Inherited Shape Line Color with Palette Accent2
//
// Description:
// This console program loads a PPTX file, creates a sample presentation if the
// input file is missing, iterates over shapes on the first slide, detects
// inherited line formatting, and replaces visible line colors with the
// Accent2 palette entry using Aspose.Slides for .NET. The modified presentation
// is saved as a new file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Detect Inherited Line Color, Palette, Accent2
//
// Use Cases:
// - Standardize line colors across existing presentations.
// - Automate visual consistency checks in batch processing.
// - Prepare presentations for corporate branding guidelines.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Create a sample input file if it does not exist
        if (!File.Exists(inputPath))
        {
            try
            {
                Aspose.Slides.Presentation samplePresentation = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide sampleSlide = samplePresentation.Slides[0];
                Aspose.Slides.IShape sampleShape = sampleSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 150);
                sampleShape.LineFormat.Width = 2;
                sampleShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                sampleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
                samplePresentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                samplePresentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create sample input file: " + ex.Message);
                Environment.Exit(1);
            }
        }

        // Load the presentation
        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            Environment.Exit(1);
        }

        // Process shapes on the first slide
        try
        {
            Aspose.Slides.ISlide firstSlide = presentation.Slides[0];
            foreach (Aspose.Slides.IShape shape in firstSlide.Shapes)
            {
                if (shape.LineFormat != null)
                {
                    Aspose.Slides.ILineFormatEffectiveData effectiveLine = shape.LineFormat.GetEffective();
                    if (effectiveLine != null && effectiveLine.Width > 0)
                    {
                        shape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        shape.LineFormat.FillFormat.SolidFillColor.SchemeColor = Aspose.Slides.SchemeColor.Accent2;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error processing shapes: " + ex.Message);
            presentation.Dispose();
            Environment.Exit(1);
        }

        // Save the modified presentation
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save presentation: " + ex.Message);
            presentation.Dispose();
            Environment.Exit(1);
        }

        presentation.Dispose();
        Console.WriteLine("Processing completed successfully. Output saved to " + outputPath);
    }
}
