// -----------------------------------------------------------------------------
// Example: Set author property and save PPTX using C#
//
// Description:
// Demonstrates how to set the Author document property of a PowerPoint presentation
// and save the modified file using Aspose.Slides for .NET. The example loads an
// existing PPTX, updates the author metadata, and writes the result to a new file.
// This pattern can be used in console applications or automated workflows that
// need to modify presentation metadata.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Author Property, Document Properties,
// Save Presentation, Presentation Metadata, Office Automation
//
// Use Cases:
// - Update author information in existing PPTX files.
// - Automate metadata management for PowerPoint presentations.
// - Integrate author property updates into .NET build or publishing pipelines.
// - Prepare presentations with correct attribution before distribution.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace UpdatePresentationAuthor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            string newAuthor = "John Doe";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Update the Author property
                IDocumentProperties properties = presentation.DocumentProperties;
                properties.Author = newAuthor;

                // Save the updated presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Presentation author updated and saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // TODO: Add handling for unsupported file formats if needed
            }
        }
    }
}
