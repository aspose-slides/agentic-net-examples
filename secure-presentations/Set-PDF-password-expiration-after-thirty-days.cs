// -----------------------------------------------------------------------------
// Example: Set PDF password expiration after thirty days using C#
//
// Description:
// Demonstrates how to set PDF password expiration after thirty days using C# 
// and Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Password, Expiration, 
// After, Thirty, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate set PDF password expiration after thirty days.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
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
