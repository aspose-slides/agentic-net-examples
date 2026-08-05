// -----------------------------------------------------------------------------
// Example: Remove every third slide using removeat using C#
//
// Description:
// Demonstrates how to remove every third slide from a PowerPoint presentation
// using the RemoveAt method in Aspose.Slides for .NET. The example loads an
// existing PPTX file, iterates through the slides in reverse order to delete
// slides whose position is a multiple of three, and saves the modified file.
// This pattern can be used in console applications or automated workflows that
// need to trim presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, RemoveAt, Every Third Slide, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate removal of every third slide from a batch of presentations.
// - Build .NET tools for cleaning up PPTX files before publishing.
// - Integrate slide manipulation logic into larger document processing pipelines.
// - Validate slide order and content programmatically.
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
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Presentation pres = new Presentation(inputPath);
            // Remove every third slide (indices 2,5,8,...). Iterate backwards because removal shifts indices.
            for (int i = pres.Slides.Count - 1; i >= 0; i--)
            {
                if ((i + 1) % 3 == 0)
                {
                    pres.Slides.RemoveAt(i);
                }
            }
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
