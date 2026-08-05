// -----------------------------------------------------------------------------
// Example: Unlock group shapes in PPTX using C#
//
// Description:
// Demonstrates how to unlock editing restrictions on group shapes in a PPTX
// file using Aspose.Slides for .NET. The example loads a presentation,
// iterates through all slides and shapes, clears lock properties on each
// group shape, and saves the modified file. This pattern can be used to
// prepare presentations for further editing or automated processing.
//
// Keywords:
// C#, Aspose.Slides, PPTX, Unlock, Group Shape, Shape Lock, Presentation,
// PowerPoint Automation, .NET
//
// Use Cases:
// - Remove editing locks from group shapes before editing or re‑using them.
// - Prepare PPTX files for batch processing where locked shapes cause issues.
// - Integrate shape unlocking into custom PowerPoint manipulation tools.
// - Ensure group shapes are editable in downstream applications.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Load the presentation with exception handling for unsupported formats
        Presentation pres = null;
        try
        {
            pres = new Presentation(inputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            // Format not supported
            return;
        }

        // Iterate through all slides and shapes to find group shapes
        foreach (ISlide slide in pres.Slides)
        {
            foreach (IShape shape in slide.Shapes)
            {
                IGroupShape groupShape = shape as IGroupShape;
                if (groupShape != null)
                {
                    // Unlock all editing restrictions on the group shape
                    groupShape.GroupShapeLock.UngroupingLocked = false;
                    groupShape.GroupShapeLock.GroupingLocked = false;
                    groupShape.GroupShapeLock.PositionLocked = false;
                    groupShape.GroupShapeLock.SizeLocked = false;
                    groupShape.GroupShapeLock.RotationLocked = false;
                    groupShape.GroupShapeLock.SelectLocked = false;
                    groupShape.GroupShapeLock.AspectRatioLocked = false;
                }
            }
        }

        // Save the modified presentation
        try
        {
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save presentation: " + ex.Message);
        }
        finally
        {
            if (pres != null)
            {
                pres.Dispose();
            }
        }
    }
}
