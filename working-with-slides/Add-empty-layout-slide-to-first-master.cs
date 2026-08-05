// -----------------------------------------------------------------------------
// Example: Add empty layout slide to first master using C#
//
// Description:
// Demonstrates how to add an empty layout slide to the first master slide of a
// PowerPoint presentation using C# and Aspose.Slides for .NET. The example
// loads an existing PPTX file, creates a blank layout slide in the first master
// collection, and saves the modified presentation. This pattern can be used to
// automate PPTX workflows, extend slide masters, or prepare templates in .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Empty, Layout, Slide, First,
// Master, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding an empty layout slide to the first master of a presentation.
// - Build C# tools for PowerPoint presentation processing and template creation.
// - Generate or modify PPTX files in .NET applications.
// - Validate and extend slide master structures before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputFile = "input.pptx";
        string outputFile = "output.pptx";

        string inputPath = Path.Combine(Environment.CurrentDirectory, inputFile);
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        Presentation pres = null;
        try
        {
            pres = new Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // Format not supported
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        var layoutSlides = pres.Masters[0].LayoutSlides;
        var newLayout = layoutSlides.Add(Aspose.Slides.SlideLayoutType.Blank, null);

        try
        {
            pres.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save presentation: " + ex.Message);
        }
        finally
        {
            pres.Dispose();
        }
    }
}
