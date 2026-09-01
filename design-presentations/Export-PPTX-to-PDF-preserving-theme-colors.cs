// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX to PDF preserving theme colors using C#

//

// Description:

// Demonstrates how to load a PPTX file and export it to PDF while preserving

// the presentation's theme colors using Aspose.Slides for .NET. The example

// configures PDF options to embed all fonts, which ensures that the visual

// appearance of the original slides, including custom theme colors, is retained

// in the generated PDF.

//

// Keywords:

// C#, Aspose.Slides, PPTX, PDF, Export, Theme Colors, Presentation Processing,

// Office Automation, Font Embedding

//

// Use Cases:

// - Convert PowerPoint presentations to PDF without losing theme color fidelity.

// - Build automated tools that generate PDF reports from PPTX files.

// - Ensure consistent branding when exporting slides to PDF in .NET applications.

// - Preserve embedded fonts and theme colors during batch conversion processes.

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

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



            // Configure PDF options to embed all fonts

            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();

            pdfOptions.EmbedFullFonts = true; // Preserve embedded fonts



            // Save the presentation as PDF (custom theme colors are preserved by default)

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);



            // Dispose the presentation

            presentation.Dispose();

        }

        catch (Exception ex)

        {

            // Handle errors such as unsupported format or other processing issues

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

