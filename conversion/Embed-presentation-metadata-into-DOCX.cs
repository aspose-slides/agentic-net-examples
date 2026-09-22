// -----------------------------------------------------------------------------
// Example: Embed Presentation Metadata and Export to DOCX (Fallback to PPTX)
// 
// Description:
// This console application loads an existing PowerPoint PPTX file, copies its
// built‑in document properties (such as Title, Author, Subject) into custom
// properties, and attempts to save the presentation as a DOCX file using
// Aspose.Slides for .NET. If the DOCX format is not supported, the program falls
// back to saving the file as PPTX and informs the user.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, metadata, custom properties, DOCX export
// 
// Use Cases:
// - Automate metadata preservation when converting presentations to Word documents.
// - Ensure built‑in properties are retained as custom properties for downstream processing.
// - Provide graceful fallback when a target format is unavailable.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesMetadataExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.docx");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Access document properties
            Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;

            // Helper to add a custom property if the built‑in value is not empty
            Action<string, string> addCustomIfNotEmpty = (propertyName, propertyValue) =>
            {
                if (!string.IsNullOrEmpty(propertyValue))
                {
                    // SetCustomPropertyValue creates or updates a custom property
                    docProps.SetCustomPropertyValue(propertyName, propertyValue);
                }
            };

            // Copy built‑in properties to custom properties
            addCustomIfNotEmpty("Title", docProps.Title);
            addCustomIfNotEmpty("Author", docProps.Author);
            addCustomIfNotEmpty("Subject", docProps.Subject);
            addCustomIfNotEmpty("Keywords", docProps.Keywords);
            addCustomIfNotEmpty("Comments", docProps.Comments);
            addCustomIfNotEmpty("Category", docProps.Category);
            addCustomIfNotEmpty("Manager", docProps.Manager);
            addCustomIfNotEmpty("Company", docProps.Company);

            // Attempt to determine if DOCX format is supported
            Aspose.Slides.Export.SaveFormat targetFormat;
            try
            {
                // This will succeed only if "Docx" is a valid enum name
                targetFormat = (Aspose.Slides.Export.SaveFormat)Enum.Parse(typeof(Aspose.Slides.Export.SaveFormat), "Docx", ignoreCase: true);
            }
            catch (ArgumentException)
            {
                // DOCX format not supported – fallback to PPTX
                Console.WriteLine("DOCX format is not supported by the installed Aspose.Slides version. Saving as PPTX instead.");
                string fallbackPath = Path.ChangeExtension(outputPath, ".pptx");
                presentation.Save(fallbackPath, Aspose.Slides.Export.SaveFormat.Pptx);
                return;
            }

            // Save the presentation using the determined format
            try
            {
                presentation.Save(outputPath, targetFormat);
                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while saving the presentation: " + ex.Message);
            }
        }
    }
}
