// -----------------------------------------------------------------------------
// Example: Convert all slides to png using foreach using C#
//
// Description:
// Demonstrates how to convert all slides to PNG using a foreach loop in C#
// with Aspose.Slides for .NET. The example shows the required presentation-
// processing steps for PowerPoint files and produces PNG images for each slide
// in a standalone console application. Developers can use this pattern to
// automate PPTX workflows, validate results, or integrate presentation logic
// into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Convert, Slides, Foreach,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate conversion of all slides to PNG using a foreach loop.
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
    static void Main()
    {
        // Path to the source presentation
        string inputPath = "input.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Format string for output PNG files
        string outputFormat = "slide_{0}.png";

        try
        {
            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Iterate through all slides using foreach and export each to PNG
            int index = 0;
            foreach (ISlide slide in pres.Slides)
            {
                using (IImage image = slide.GetImage())
                {
                    string outputPath = string.Format(outputFormat, index);
                    image.Save(outputPath, ImageFormat.Png);
                }
                index++;
            }

            // No modifications made to the presentation, so saving is optional.
            // pres.Save(inputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
