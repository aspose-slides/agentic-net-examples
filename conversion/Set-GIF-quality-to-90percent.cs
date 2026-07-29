// -----------------------------------------------------------------------------
// Example: Set GIF quality to 90percent using C#
//
// Description:
// Demonstrates how to set GIF quality to 90percent using C# and Aspose.Slides 
// for .NET. The example shows the required presentation-processing steps for 
// PowerPoint files and produces the requested output in a standalone console 
// application. Developers can use this pattern to automate PPTX workflows, 
// validate results, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, GIF, Quality, 90Percent, 
// GifOptions.CompressionLevel, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting GIF quality to 90percent.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files into high‑quality animated GIFs in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.gif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Initialize GIF export options
                GifOptions gifOptions = new GifOptions();

                // Set GIF quality to 90 percent (CompressionLevel ranges from 0 to 100)
                gifOptions.CompressionLevel = 90;

                // Example of other configurable options (optional)
                // gifOptions.FrameSize = new System.Drawing.Size(960, 720);
                // gifOptions.TransitionFps = 35;

                // Save the presentation as an animated GIF
                presentation.Save(outputPath, SaveFormat.Gif, gifOptions);
            }
        }
        catch (NotSupportedException ex)
        {
            // Handle unsupported format scenario
            Console.WriteLine("Format not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
