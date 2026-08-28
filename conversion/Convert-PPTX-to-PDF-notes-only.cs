// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert PPTX to PDF notes only using C#

//

// Description:

// Demonstrates how to convert a PPTX presentation to a PDF containing only

// the speaker notes using Aspose.Slides for .NET. The example loads a PPTX

// file, configures the PDF options to layout notes at the bottom of each page,

// and saves the result as a PDF. This pattern can be used in console

// applications or automated workflows that need to extract notes from PowerPoint

// files.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Convert, Notes Only,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Extract speaker notes from PPTX files into PDF format.

// - Automate generation of notes-only PDFs for review or distribution.

// - Integrate notes extraction into .NET applications or CI pipelines.

// - Validate and process PowerPoint presentations programmatically.

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

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            using (Presentation presentation = new Presentation(inputPath))

            {

                PdfOptions pdfOptions = new PdfOptions();

                NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();

                layoutOptions.NotesPosition = NotesPositions.BottomFull;

                pdfOptions.SlidesLayoutOptions = layoutOptions;



                presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);

            }

        }

        catch (PptxUnsupportedFormatException)

        {

            // Format not supported

            Console.WriteLine("The provided file format is not supported for conversion.");

        }

        catch (Exception ex)

        {

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

