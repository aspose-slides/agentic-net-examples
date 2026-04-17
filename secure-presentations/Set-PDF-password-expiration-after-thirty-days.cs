using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPdfPath = "output.pdf";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Set PDF user password
                string pdfPassword = "UserPassword123";
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.Password = pdfPassword;

                // Add custom property indicating password expiration after 30 days
                IDocumentProperties docProps = presentation.DocumentProperties;
                DateTime expirationDate = DateTime.UtcNow.AddDays(30);
                docProps.SetCustomPropertyValue("PasswordExpiration", expirationDate);

                // Save the presentation as PDF with the specified options
                presentation.Save(outputPdfPath, SaveFormat.Pdf, pdfOptions);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The specified file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URLs or web services)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}