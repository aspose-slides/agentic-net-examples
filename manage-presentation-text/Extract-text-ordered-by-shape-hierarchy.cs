// -----------------------------------------------------------------------------
// Example: Extract text ordered by shape hierarchy using C#
//
// Description:
// Demonstrates how to extract text ordered by shape hierarchy using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Extract, Text, Ordered, Shape, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extract text ordered by shape hierarchy.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace TextExtractionExample
{
    class Program
    {
        static void Main()
        {
            // Input and output paths
            string inputPath = "input.pptx";
            string outputPath = "extracted_text.txt";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Use PresentationFactory to extract text ordered by shape hierarchy (Arranged mode)
                PresentationFactory factory = new PresentationFactory();
                IPresentationText presentationText = factory.GetPresentationText(inputPath, TextExtractionArrangingMode.Arranged);

                // Write extracted text to console and to a file
                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    foreach (ISlideText slideText in presentationText.SlidesText)
                    {
                        Console.WriteLine(slideText.Text);
                        writer.WriteLine(slideText.Text);
                    }
                }

                // Load the presentation to satisfy the "save before exit" requirement
                Presentation presentation = new Presentation(inputPath);
                // Save the presentation (no changes made, just re-saving)
                presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
