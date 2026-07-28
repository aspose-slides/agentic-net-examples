// -----------------------------------------------------------------------------
// Example: Duplicate slide insert after change background using C#
//
// Description:
// Demonstrates how to duplicate a slide, insert it at a specific position,
// and change its background color using C# and Aspose.Slides for .NET. The
// example shows the required presentation-processing steps for PowerPoint
// files and produces the requested output in a standalone console application.
// Developers can use this pattern to automate PPTX workflows, validate results,
// or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Duplicate, Slide, Insert,
// Background, Change, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate duplicate slide insertion with background color change.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Presentation presentation = new Presentation(inputPath);

            // Index of the slide to duplicate (zero-based)
            int sourceSlideIndex = 1;
            // Position to insert the duplicated slide (after slide index 2)
            int insertPosition = 3;

            // Duplicate the slide and insert it at the specified position
            ISlide clonedSlide = presentation.Slides.InsertClone(insertPosition, presentation.Slides[sourceSlideIndex]);

            // Change background color of the duplicated slide to Red
            clonedSlide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            clonedSlide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            clonedSlide.Background.FillFormat.SolidFillColor.Color = Color.Red;

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format, external resource errors)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
