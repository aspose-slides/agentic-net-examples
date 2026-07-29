// -----------------------------------------------------------------------------
// Example: Set GIF loop count to 1 using C#
//
// Description:
// Demonstrates how to set GIF loop count to 1 using C# and Aspose.Slides for 
// .NET. The example shows the required presentation-processing steps for 
// PowerPoint files and produces the requested output in a standalone console 
// application. Developers can use this pattern to automate PPTX workflows, 
// validate results, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, GIF, LoopCount, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting GIF loop count to 1.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Determine input file path (default or from command line)
        string inputPath = "input.pptx";
        if (args.Length > 0)
        {
            inputPath = args[0];
        }

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Create GIF export options and set loop count to 1
                GifOptions gifOptions = new GifOptions
                {
                    LoopCount = 1 // Set the GIF to loop only once
                };

                // Define output path with .gif extension
                string outputPath = Path.ChangeExtension(inputPath, ".gif");

                // Save the presentation as an animated GIF
                pres.Save(outputPath, SaveFormat.Gif, gifOptions);
                Console.WriteLine("GIF saved to: " + outputPath);
            }
        }
        catch (NotSupportedException)
        {
            // Handle case where GIF format is not supported
            Console.WriteLine("GIF format not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
