// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX notes to handout view using C#

//

// Description:

// Demonstrates how to export PPTX notes to a handout view PDF using C# and 

// Aspose.Slides for .NET. The example loads a PowerPoint presentation, configures

// the notes layout to appear at the bottom of each slide, and saves the result

// as a PDF file. This pattern can be used to automate the creation of handout

// PDFs that include speaker notes.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, PDF, Notes, Handout, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate export of PPTX notes to handout view PDFs.

// - Build C# tools for PowerPoint presentation processing with notes.

// - Generate handout PDFs that include slide notes in .NET applications.

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

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();

            Aspose.Slides.Export.NotesCommentsLayoutingOptions notesOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();

            notesOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;

            pdfOptions.SlidesLayoutOptions = notesOptions;

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

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

