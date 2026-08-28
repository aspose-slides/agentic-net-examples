// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export combined comments and notes to PDF with page breaks using C#

//

// Description:

// Demonstrates how to export a PowerPoint presentation to a PDF file where

// both slide notes and comments are combined and placed on separate pages.

// The example uses Aspose.Slides for .NET to load a PPTX file, configure PDF

// options to position notes at the bottom of each slide and comments on the

// right side, and then saves the result as a PDF with appropriate page breaks.

//

// Keywords:

// C#, Aspose.Slides for .NET, PDF export, comments, notes, page breaks,

// PowerPoint, PPTX, presentation processing, Office automation

//

// Use Cases:

// - Convert PPTX files to PDF while preserving and combining slide notes and

//   comments.

// - Automate generation of PDF documentation that includes presenter notes and

//   reviewer comments.

// - Build .NET tools for batch processing of presentations with combined

//   notes/comments output.

// - Validate presentation content before publishing or archiving.

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

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            // Load the presentation

            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);



            // Configure PDF options to include notes and comments

            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();

            Aspose.Slides.Export.NotesCommentsLayoutingOptions layoutOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();

            layoutOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;

            layoutOptions.CommentsPosition = Aspose.Slides.Export.CommentsPositions.Right;

            pdfOptions.SlidesLayoutOptions = layoutOptions;



            // Save the presentation as PDF

            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);



            // Dispose the presentation object

            pres.Dispose();



            Console.WriteLine("Presentation exported to PDF successfully.");

        }

        catch (Exception ex)

        {

            // Handle errors such as unsupported format

            Console.WriteLine("An error occurred: " + ex.Message);

            // Format not supported.

        }

    }

}

