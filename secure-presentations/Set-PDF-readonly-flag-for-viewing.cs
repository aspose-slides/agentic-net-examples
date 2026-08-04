// -----------------------------------------------------------------------------
// Example: Set PDF readonly flag for viewing using C#
//
// Description:
// Demonstrates how to set the PDF read‑only (viewing) flag using C# and 
// Aspose.Slides for .NET. The example creates a simple PowerPoint presentation,
// applies the read‑only recommendation, and then saves the file as a PDF with
// the read‑only permission enabled. This pattern can be used in console
// applications, automation scripts, or any .NET solution that needs to produce
// PDF files that are restricted to view‑only mode.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Readonly, Flag, Viewing, 
// PDF Permissions, Presentation Processing, Office Automation
//
// Use Cases:
// - Generate PDF presentations that cannot be edited or modified.
// - Build C# tools for secure PDF export from PowerPoint files.
// - Automate PDF permission settings in batch processing pipelines.
// - Validate presentation export workflows before publishing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReadOnlyPresentationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output folder and file name
            var outFolder = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            var outPdfFile = Path.Combine(outFolder, "ReadOnlyPresentation.pdf");

            // Ensure output directory exists
            if (!Directory.Exists(outFolder))
                Directory.CreateDirectory(outFolder);

            // Create a new presentation
            using (var presentation = new Presentation())
            {
                // Set the read‑only recommendation flag for the presentation
                presentation.ProtectionManager.ReadOnlyRecommended = true;

                // Configure PDF export options to set the read‑only (viewing) flag
                var pdfOptions = new PdfOptions
                {
                    // The AccessPermissions enum includes a ReadOnly flag that restricts
                    // editing, copying, and other modifications while allowing viewing.
                    AccessPermissions = PdfAccessPermissions.ReadOnly
                };

                try
                {
                    // Save the presentation as a PDF with the read‑only flag applied
                    presentation.Save(outPdfFile, SaveFormat.Pdf, pdfOptions);
                }
                catch (Exception ex)
                {
                    // Handle any exceptions (e.g., unsupported format or permission issues)
                    Console.WriteLine("Error saving PDF presentation: " + ex.Message);
                }
            }

            Console.WriteLine("PDF presentation saved to: " + outPdfFile);
        }
    }
}
