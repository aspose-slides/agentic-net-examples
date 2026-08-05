// -----------------------------------------------------------------------------
// Example: Validate slide dimensions against template using C#
//
// Description:
// Demonstrates how to validate slide dimensions against a template using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, Slide, Dimensions, 
// Template, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate validation of slide dimensions against a predefined template.
// - Build C# tools for PowerPoint presentation processing and quality checks.
// - Generate or transform PPTX files in .NET applications while ensuring size compliance.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "template.pptx";
        string outputPath = "validated_output.pptx";

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

        // Define the expected slide dimensions (width x height in points)
        SizeF templateSize = new SizeF(960f, 540f);

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Retrieve the presentation's slide size
                ISlideSize slideSize = presentation.SlideSize;
                SizeF actualSize = slideSize.Size;

                // Compare actual dimensions with the template
                if (actualSize.Width != templateSize.Width || actualSize.Height != templateSize.Height)
                {
                    Console.WriteLine("Slide dimensions do not match the template. Expected: {0}x{1}, Actual: {2}x{3}",
                        templateSize.Width, templateSize.Height, actualSize.Width, actualSize.Height);
                }
                else
                {
                    Console.WriteLine("All slide dimensions match the template.");
                }

                // Save the presentation before exiting
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException ex)
        {
            // Handle unsupported PPTX format
            Console.WriteLine("Unsupported PPTX format: " + ex.Message);
        }
        catch (Aspose.Slides.PptUnsupportedFormatException ex)
        {
            // Handle unsupported PPT format
            Console.WriteLine("Unsupported PPT format: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
