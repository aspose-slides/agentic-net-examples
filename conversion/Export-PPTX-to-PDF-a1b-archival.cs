// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX to PDF a1b archival using C#

//

// Description:

// Demonstrates how to export a PPTX file to a PDF/A-1b archival PDF using C#

// and Aspose.Slides for .NET. The example loads a PowerPoint presentation,

// configures PDF options for PDF/A-1b compliance, and saves the result as a

// PDF file. This pattern can be used in console applications to automate

// archival-ready PDF generation from PowerPoint files.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Export, PDF/A-1b, Archival,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX to PDF/A-1b for long-term archiving.

// - Build C# utilities for PowerPoint document preservation.

// - Integrate PDF/A-1b export into .NET applications handling presentations.

// - Validate and generate archival-compliant PDFs before distribution.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Define input and output file paths

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

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



            // Set PDF options with PDF/A‑1b compliance

            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();

            pdfOptions.Compliance = Aspose.Slides.Export.PdfCompliance.PdfA1b;



            // Save the presentation as PDF/A‑1b

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);



            // Release resources

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

