using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportPptxToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file (password‑protected) and output PDF file paths
            string inputPath = "protected.pptx";
            string outputPath = "protected.pdf";
            // Password used to open the PPTX and to protect the PDF
            string password = "myPassword";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the encrypted presentation using the password
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.Password = password;
                using (Presentation presentation = new Presentation(inputPath, loadOptions))
                {
                    // Configure PDF export options and retain the same password
                    PdfOptions pdfOptions = new PdfOptions();
                    pdfOptions.Password = password; // protect the PDF with the same password

                    // Export the presentation to PDF
                    presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);
                }

                Console.WriteLine("Presentation exported to PDF successfully.");
            }
            catch (InvalidPasswordException)
            {
                // Thrown when the provided password is incorrect
                Console.WriteLine("The provided password is incorrect.");
            }
            catch (NotSupportedException)
            {
                // Thrown when trying to save an encrypted file to an unsupported format
                Console.WriteLine("The requested save format is not supported for encrypted presentations.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}