// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Protect PDF with Secure123 password using C#

//

// Description:

// Demonstrates how to protect a PDF with the Secure123 password using C# and 

// Aspose.Slides for .NET. The example loads a PowerPoint presentation, applies 

// PDF export options with password protection, and saves the result as a 

// password‑protected PDF file. This pattern can be used to automate PPTX to PDF 

// conversion with security in .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Protect, Secure123, 

// Password, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX to password‑protected PDF.

// - Build C# tools for securing exported presentation PDFs.

// - Integrate PDF protection into PowerPoint processing workflows.

// - Ensure confidential presentation content is protected before distribution.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Define input and output paths

        string inputPath = "input.pptx";

        string outputPath = "output.pdf";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            // Load the presentation

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



            // Set PDF options with password protection

            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();

            pdfOptions.Password = "Secure123";



            // Save as password‑protected PDF

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);



            // Dispose the presentation

            presentation.Dispose();

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other errors

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

