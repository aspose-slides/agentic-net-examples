// -----------------------------------------------------------------------------
// Example: Add multiple empty slides and set tags using C#
//
// Description:
// Demonstrates how to add multiple empty slides and set tags using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Multiple, Empty, Slides, Tags, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate add multiple empty slides and set tags.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create output directory
        string outputDir = Path.Combine(Environment.CurrentDirectory, "Output");
        if (!Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Number of slides to add
        int slideCount = 5;

        for (int i = 0; i < slideCount; i++)
        {
            // Add an empty slide using the first layout slide
            Aspose.Slides.ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

            // Assign a unique custom tag
            pres.CustomData.Tags["SlideTag" + i] = "TagValue" + i;
        }

        // Save the presentation
        string outPath = Path.Combine(outputDir, "BatchSlides.pptx");
        try
        {
            pres.Save(outPath, SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported or other error handling
        }

        // Dispose the presentation
        pres.Dispose();
    }
}
