// -----------------------------------------------------------------------------
// Example: Add multiple custom COM references and verify using C#
//
// Description:
// Demonstrates how to add multiple custom COM references, read document
// properties via the COM interface, verify load formats, and merge slides
// using Aspose.Slides for .NET. The example loads two PPTX files, extracts
// their properties, confirms the presentation formats, clones a slide from
// the second presentation into the first, and saves the merged result.
// This pattern helps developers automate PowerPoint workflows that require
// COM-based metadata access and presentation manipulation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, COM, DocumentProperties,
// LoadFormat, Merge Slides, Presentation Processing, Automation
//
// Use Cases:
// - Automate reading presentation metadata via COM interfaces.
// - Verify presentation load formats before processing.
// - Merge slides from multiple presentations programmatically.
// - Build .NET tools for PowerPoint file validation and transformation.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths to the input presentations and output file
        string inputPath1 = "sample1.pptx";
        string inputPath2 = "sample2.pptx";
        string outputPath = "merged_output.pptx";

        // Verify that the input files exist
        if (!File.Exists(inputPath1))
        {
            Console.WriteLine("Input file not found: " + inputPath1);
            return;
        }
        if (!File.Exists(inputPath2))
        {
            Console.WriteLine("Input file not found: " + inputPath2);
            return;
        }

        try
        {
            // Load presentation info via COM interface for the first file
            Aspose.Slides.IPresentationInfo info1 = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(inputPath1);
            Aspose.Slides.IDocumentProperties props1 = info1.ReadDocumentProperties();

            // Load presentation info via COM interface for the second file
            Aspose.Slides.IPresentationInfo info2 = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(inputPath2);
            Aspose.Slides.IDocumentProperties props2 = info2.ReadDocumentProperties();

            // Output load formats to verify correct loading
            Aspose.Slides.LoadFormat format1 = info1.LoadFormat;
            Aspose.Slides.LoadFormat format2 = info2.LoadFormat;
            Console.WriteLine("First presentation format: " + format1);
            Console.WriteLine("Second presentation format: " + format2);

            // Open the presentations
            Aspose.Slides.Presentation pres1 = new Aspose.Slides.Presentation(inputPath1);
            Aspose.Slides.Presentation pres2 = new Aspose.Slides.Presentation(inputPath2);

            // Clone the first slide of the second presentation into the first presentation
            Aspose.Slides.ISlideCollection slides1 = pres1.Slides;
            slides1.AddClone(pres2.Slides[0]);

            // Save the merged presentation before exiting
            pres1.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            Console.WriteLine("Merged presentation saved to: " + outputPath);

            // Dispose presentations
            pres1.Dispose();
            pres2.Dispose();
        }
        catch (Exception ex)
        {
            // Handle format not supported or other errors
            // Comment: format not supported
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
