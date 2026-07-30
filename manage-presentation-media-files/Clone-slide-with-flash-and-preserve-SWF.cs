// -----------------------------------------------------------------------------
// Example: Clone slide with flash and preserve SWF using C#
//
// Description:
// Demonstrates how to clone a slide that contains a Flash (SWF) object and
// preserve the embedded SWF file while saving the presentation using
// Aspose.Slides for .NET. The example loads an existing PPTX, clones the first
// slide, and saves the result as a new PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone, Slide, Flash, SWF,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cloning of slides that contain Flash objects while keeping the
//   original SWF content intact.
// - Build .NET utilities for managing PowerPoint media assets.
// - Generate or modify PPTX files programmatically in enterprise workflows.
// - Validate presentation transformations that involve embedded media.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "source.pptx";
        string outputPath = "cloned_output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.ISlideCollection slides = pres.Slides;
            // Clone the first slide (assumed to contain a flash object) to the end of the collection
            slides.AddClone(slides[0]);
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The presentation format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., file access, loading errors)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
