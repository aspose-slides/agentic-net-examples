// -----------------------------------------------------------------------------
// Example: Read revision number increment and store using C#
//
// Description:
// Demonstrates how to read the current revision number of a PowerPoint presentation,
// increment it, and store the updated value using Aspose.Slides for .NET. The example
// loads an existing PPTX file, modifies its document properties, and saves the
// result to a new file. This pattern is useful for automating version tracking
// in presentation workflows.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Read, Revision, Number, Increment,
// Document Properties, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate revision number increment for PowerPoint files.
// - Build C# tools that manage presentation versioning.
// - Integrate revision tracking into .NET applications handling PPTX files.
// - Ensure consistent document metadata before publishing or archiving.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RevisionNumberUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Load the presentation
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle loading errors (e.g., unsupported format)
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            try
            {
                // Access document properties
                Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;

                // Read the current revision number, increment it, and store back
                int currentRevision = documentProperties.RevisionNumber;
                documentProperties.RevisionNumber = currentRevision + 1;

                // Save the updated presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any errors during property modification or saving
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                // Ensure resources are released
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}
