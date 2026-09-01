// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert PPTX selected slides to PDF a1b using C#

//

// Description:

// Demonstrates how to convert specific slides (1, 4, and 9) from a PPTX file 

// to a PDF/A‑1b compliant document using C# and Aspose.Slides for .NET. The 

// example loads a presentation, configures PDF/A‑1b compliance, and saves the 

// chosen slides as a PDF file in a standalone console application. This pattern 

// can be used to automate slide selection, ensure PDF/A compliance, and 

// integrate presentation conversion into .NET solutions.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, PDF/A‑1b, Convert, Pptx, 

// Selected, Slides, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of selected PPTX slides to PDF/A‑1b.

// - Build C# tools for selective slide export with compliance requirements.

// - Generate PDF/A‑1b documents from PowerPoint presentations in .NET apps.

// - Validate and process specific slides before publishing or archiving.

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

        var inputPath = "input.pptx";

        var outputPath = "output.pdf";



        // Verify input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load presentation

            var presentation = new Presentation(inputPath);



            // Set PDF options with PDF/A‑1b compliance

            var pdfOptions = new PdfOptions();

            pdfOptions.Compliance = PdfCompliance.PdfA1b;



            // Save selected slides (1, 4, 9) as PDF

            presentation.Save(outputPath, new int[] { 1, 4, 9 }, SaveFormat.Pdf, pdfOptions);



            // Dispose presentation

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // Format not supported

            // Comment: format not supported

        }

        catch (Exception ex)

        {

            // Handle other exceptions (e.g., I/O errors)

            Console.WriteLine($"Error: {ex.Message}");

        }

    }

}

