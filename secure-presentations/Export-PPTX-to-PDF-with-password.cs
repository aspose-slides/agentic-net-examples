// -----------------------------------------------------------------------------
// Example: Export PPTX to PDF with password using C#
//
// Description:
// Demonstrates how to export a password‑protected PPTX file to a password‑protected
// PDF using C# and Aspose.Slides for .NET. The example shows how to load an
// encrypted presentation, apply matching encryption settings to the PDF output,
// and handle common errors in a standalone console application. Developers can
// use this pattern to automate secure presentation workflows, validate results,
// or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Export, Password, Secure,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate export of password‑protected PPTX files to password‑protected PDFs.
// - Build C# tools for secure PowerPoint presentation processing.
// - Generate or transform encrypted PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SecurePresentationExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "protected.pptx";
            string outputPath = "protected.pdf";
            // Password used to open the encrypted presentation
            string password = "myPassword";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Set load options with the password to open the encrypted PPTX
            LoadOptions loadOptions = new LoadOptions();
            loadOptions.Password = password;

            try
            {
                // Load the password‑protected presentation
                using (Presentation presentation = new Presentation(inputPath, loadOptions))
                {
                    // Prepare PDF export options and retain the same password
                    PdfOptions pdfOptions = new PdfOptions();
                    pdfOptions.Password = password;

                    // Export to PDF while preserving encryption settings
                    presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);
                }

                Console.WriteLine("Presentation exported successfully to PDF.");
            }
            catch (PptxUnsupportedFormatException)
            {
                // Handle unsupported file format during save
                Console.WriteLine("The specified format is not supported for saving.");
            }
            catch (NotSupportedException)
            {
                // Handle other not‑supported operations (e.g., saving encrypted file to an unsupported format)
                Console.WriteLine("The operation is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
