// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set custom notes position for PDF note pages using C#

//

// Description:

// Demonstrates how to set a custom notes position for PDF note pages using C#

// and Aspose.Slides for .NET. The example loads a PPTX presentation, configures

// the notes layout to appear at the bottom of each slide in the generated PDF,

// and saves the result. This pattern can be used to automate PPTX to PDF

// conversion with customized note placement.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Notes, Note Pages, 

// Presentation Processing, Office Automation, Custom Layout

//

// Use Cases:

// - Convert PPTX to PDF with notes positioned at the bottom.

// - Build C# tools for PowerPoint presentation processing with custom note layout.

// - Generate PDFs from presentations for documentation or review purposes.

// - Automate presentation workflows that require specific note placement.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        var inputPath = "input.pptx";

        var outputPath = "output.pdf";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            using (var pres = new Aspose.Slides.Presentation(inputPath))

            {

                var pdfOptions = new Aspose.Slides.Export.PdfOptions();

                var notesOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();

                notesOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;

                pdfOptions.SlidesLayoutOptions = notesOptions;



                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

            }

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other errors

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

