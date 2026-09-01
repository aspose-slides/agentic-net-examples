// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Apply PDF/A-1b compliance to PDF using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation (PPTX) to a PDF file

// that conforms to the PDF/A-1b archival standard using Aspose.Slides for .NET.

// The example loads a presentation, configures PDF export options for PDF/A-1b

// compliance, and saves the result as a PDF document in a console application.

// This pattern can be used to automate PPTX to PDF/A conversion, ensure

// regulatory compliance, or integrate archival PDF generation into .NET apps.

//

// Keywords:

// C#, Aspose.Slides for .NET, PDF/A-1b, PDF compliance, PowerPoint, PPTX,

// PDF conversion, Archival, Presentation processing, Office automation

//

// Use Cases:

// - Convert PPTX files to PDF/A-1b compliant PDFs for long‑term storage.

// - Build C# utilities that enforce PDF archival standards on generated PDFs.

// - Integrate PDF/A-1b conversion into automated document workflows.

// - Validate presentation output before publishing or distribution.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Input and output file paths

        string inputPath = "input.pptx";

        string outputPath = "output.pdf";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the presentation

            var presentation = new Aspose.Slides.Presentation(inputPath);



            // Set PDF options for PDF/A-1b compliance

            var pdfOptions = new Aspose.Slides.Export.PdfOptions

            {

                Compliance = Aspose.Slides.Export.PdfCompliance.PdfA1b

            };



            // Save the presentation as PDF with the specified compliance

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);



            // Dispose the presentation

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

