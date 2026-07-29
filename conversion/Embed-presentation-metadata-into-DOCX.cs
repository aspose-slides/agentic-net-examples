// -----------------------------------------------------------------------------
// Example: Embed presentation metadata into DOCX using C#
//
// Description:
// Demonstrates how to embed built‑in presentation metadata as custom properties
// and save the PowerPoint file as a DOCX document using C# and Aspose.Slides for .NET.
// The example loads a PPTX file, copies standard document properties to custom
// properties, and writes the result to a DOCX file. This pattern can be used to
// automate metadata handling and generate Word‑compatible representations of
// presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Embed, Presentation, Metadata,
// Docx, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate embedding presentation metadata into DOCX.
// - Build C# tools for PowerPoint presentation processing and export.
// - Generate Word documents from PPTX files with preserved metadata.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace EmbedMetadata
{
    class Program
    {
        static void Main()
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.docx"; // Target DOCX format

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Access built‑in document properties
                IDocumentProperties properties = presentation.DocumentProperties;

                // Embed built‑in properties as custom properties
                properties.SetCustomPropertyValue("Author", properties.Author);
                properties.SetCustomPropertyValue("Title", properties.Title);
                properties.SetCustomPropertyValue("Subject", properties.Subject);
                properties.SetCustomPropertyValue("Category", properties.Category);
                properties.SetCustomPropertyValue("Comments", properties.Comments);
                properties.SetCustomPropertyValue("Company", properties.Company);
                properties.SetCustomPropertyValue("CreatedTime", properties.CreatedTime);
                properties.SetCustomPropertyValue("LastSavedTime", properties.LastSavedTime);
                properties.SetCustomPropertyValue("Manager", properties.Manager);
                properties.SetCustomPropertyValue("PresentationFormat", properties.PresentationFormat);

                // Save as DOCX
                try
                {
                    presentation.Save(outputPath, SaveFormat.Docx);
                }
                catch (Exception ex)
                {
                    // Handle any errors that occur during saving
                    Console.WriteLine("An error occurred while saving: " + ex.Message);
                }
            }

            // Ensure the presentation is saved before exiting
            Console.WriteLine("Processing completed.");
        }
    }
}
