// -----------------------------------------------------------------------------
// Example: Set slide size to custom aspect 16 9 using C#
//
// Description:
// Demonstrates how to set a PowerPoint presentation's slide size to a custom
// 16:9 aspect ratio using C# and Aspose.Slides for .NET. The example loads an
// existing PPTX file, applies a 960x540 point slide size without scaling the
// existing content, and saves the result. This pattern can be used to automate
// slide‑size adjustments in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Slide, Size, Custom, Aspect,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting slide size to a custom 16:9 aspect ratio.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with specific slide dimensions.
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
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Set custom slide size with a 16:9 aspect ratio (e.g., 960x540 points)
                presentation.SlideSize.SetSize(960f, 540f, SlideSizeScaleType.DoNotScale);

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported file format
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
