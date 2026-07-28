// -----------------------------------------------------------------------------
// Example: Load presentation modify title and resave using C#
//
// Description:
// Demonstrates how to load a PowerPoint presentation from a ZIP file, modify
// its document title property, and resave it using Aspose.Slides for .NET with
// Zip64 mode enabled. The example includes error handling for missing input
// files and unsupported formats.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load Presentation, Modify Title,
// Save Presentation, Zip64Mode, Document Properties, Office Automation
//
// Use Cases:
// - Update the title metadata of existing PowerPoint files programmatically.
// - Ensure large presentations are saved with Zip64 support.
// - Build .NET utilities for batch processing of PPTX files.
// - Integrate presentation metadata updates into automated workflows.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.zip");
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Presentation pres = new Presentation(inputPath);
            IDocumentProperties props = pres.DocumentProperties;
            props.Title = "Updated Title";

            pres.Save(inputPath, SaveFormat.Pptx, new PptxOptions()
            {
                Zip64Mode = Zip64Mode.Always
            });

            pres.Dispose();
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
