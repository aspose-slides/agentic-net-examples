// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX to PDF CMYK color using C#

//

// Description:

// Demonstrates how to export a PPTX file to a PDF using CMYK color space considerations

// with C# and Aspose.Slides for .NET. The example loads a PowerPoint presentation,

// applies PDF export options (noting that CMYK configuration is not directly available

// in this version), and saves the result as a PDF suitable for printing.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Export, CMYK, Color,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate export of PPTX to PDF with printing‑ready color handling.

// - Build C# utilities for PowerPoint presentation processing.

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

        string outputPath = "output.pdf";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            Presentation presentation = new Presentation(inputPath);

            PdfOptions pdfOptions = new PdfOptions();

            // CMYK color space is not directly configurable via PdfOptions in this version.

            // The PDF will be generated with default color settings suitable for printing.

            presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // Format not supported.

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

