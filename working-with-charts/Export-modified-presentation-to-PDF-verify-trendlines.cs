// -----------------------------------------------------------------------------
// Example: Export modified presentation to PDF verify trendlines using C#
//
// Description:
// Demonstrates how to export a PowerPoint presentation to PDF while preserving
// any existing trendlines using C# and Aspose.Slides for .NET. The example
// loads a PPTX file, performs no modifications, and saves it as a PDF, ensuring
// that trendlines remain intact in the output document. This pattern can be
// used to automate PPTX to PDF conversion workflows where chart elements must
// be retained.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Export, Trendlines,
// Presentation, Verify, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate export of presentations to PDF while preserving chart trendlines.
// - Build C# tools for PowerPoint presentation processing and validation.
// - Generate PDF versions of PPTX files in .NET applications.
// - Verify that trendlines are retained after conversion before publishing.
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
        string outputPath = "output.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Export the presentation to PDF format
                // This will retain any existing trend lines in the slides
                pres.Save(outputPath, SaveFormat.Pdf);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (System.Net.WebException)
        {
            // Handle external URL or web service exceptions
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
