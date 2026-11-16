// -----------------------------------------------------------------------------
// Example: Clone Slide and Insert Rectangle Shape in PowerPoint using C#
//
// Description:
// Demonstrates cloning an existing slide, appending it to a presentation, and
// adding a rectangle shape to the cloned slide with Aspose.Slides for .NET.
// The program creates a sample PPTX if none exists, modifies it, and saves the result.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone Slide, Add Shape, Presentation Automation
//
// Use Cases:
// - Duplicate a slide and enrich it with additional visual elements.
// - Automate slide cloning in batch processing of presentations.
// - Generate or transform PPTX files with custom shapes programmatically.
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

        if (!File.Exists(inputPath))
        {
            try
            {
                Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide firstSlide = samplePres.Slides[0];
                firstSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
                samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                samplePres.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create sample input file: " + ex.Message);
                Environment.Exit(1);
            }
        }

        try
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.ISlide sourceSlide = pres.Slides[0];
            Aspose.Slides.ISlide clonedSlide = pres.Slides.AddClone(sourceSlide);
            clonedSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Aspose.Slides.PptxEditException)
        {
            Console.WriteLine("The presentation format is not supported.");
            Environment.Exit(1);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            Environment.Exit(1);
        }
    }
}
