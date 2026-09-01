// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX to PDF (Notes Only) using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation (PPTX) and export only its

// slide notes to a PDF file using Aspose.Slides for .NET. The example includes

// file existence checking, PDF export options configuration for notes-only

// layout, and basic error handling in a console application.

//

// Keywords:

// C#, Aspose.Slides, PPTX, PDF, Notes Only, Export, Presentation Processing,

// Office Automation, .NET

//

// Use Cases:

// - Generate PDF documents that contain only the speaker notes from a PPTX.

// - Automate creation of handouts or documentation from PowerPoint notes.

// - Integrate notes‑only PDF export into .NET tools or CI pipelines.

// - Validate that notes are correctly extracted from presentations.

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

            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);



            // Configure PDF export options to use the NotesOnly layout

            Aspose.Slides.Export.PdfOptions options = new Aspose.Slides.Export.PdfOptions();

            options.SlidesLayoutOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();



            // Save the presentation as PDF with the specified options

            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, options);



            // Release resources

            pres.Dispose();

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other errors

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

