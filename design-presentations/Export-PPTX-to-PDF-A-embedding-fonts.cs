// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX to PDF/A embedding fonts using C#

//

// Description:

// Demonstrates how to export a PPTX file to a PDF/A‑1b document with full

// font embedding using C# and Aspose.Slides for .NET. The example loads a

// presentation, configures PDF options for PDF/A compliance and full font

// embedding, and saves the result as a PDF file.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF/A, Export, Font Embedding,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Convert PowerPoint presentations to PDF/A for long‑term archiving.

// - Ensure all fonts are embedded to guarantee visual fidelity across devices.

// - Automate PDF/A generation in batch processing or CI pipelines.

// - Integrate PDF/A export functionality into .NET applications.

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

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            // Load the presentation

            Presentation pres = new Presentation(inputPath);



            // Configure PDF options for PDF/A compliance and full font embedding

            PdfOptions pdfOptions = new PdfOptions();

            pdfOptions.EmbedFullFonts = true;

            pdfOptions.Compliance = PdfCompliance.PdfA1b;



            // Save the presentation as PDF/A

            pres.Save(outputPath, SaveFormat.Pdf, pdfOptions);



            // Dispose the presentation

            pres.Dispose();

        }

        catch (Exception ex)

        {

            // Handle errors such as unsupported format

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

