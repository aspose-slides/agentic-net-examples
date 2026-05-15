using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetPdfPasswordExpiration
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file '{inputPath}' does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Set a custom document property indicating password expiration (30 days from now)
                    IDocumentProperties docProps = presentation.DocumentProperties;
                    DateTime expirationDate = DateTime.UtcNow.AddDays(30);
                    docProps.SetCustomPropertyValue("PasswordExpiration", expirationDate);

                    // Configure PDF export options with a user password
                    PdfOptions pdfOptions = new PdfOptions();
                    pdfOptions.Password = "UserPassword123";

                    // Save the presentation as a password‑protected PDF
                    presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);
                }

                Console.WriteLine($"Presentation saved successfully to '{outputPath}'.");
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Handle unsupported PPTX format
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Handle unsupported PPT format
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., web service errors)
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}