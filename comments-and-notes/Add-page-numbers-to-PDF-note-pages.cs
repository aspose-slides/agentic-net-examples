// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add page numbers to PDF note pages using C#

//

// Description:

// Demonstrates how to add slide numbers to the notes pages of a PDF generated

// from a PowerPoint presentation using C# and Aspose.Slides for .NET. The

// example ensures each slide has a notes slide, enables slide number visibility

// on those notes slides, and configures PDF export to include the notes pages

// with the slide numbers displayed.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Page Numbers, Note Pages,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate the addition of slide numbers to PDF note pages.

// - Build C# utilities for processing PowerPoint presentations and exporting

//   them to PDF with annotated notes.

// - Generate PDFs with detailed slide information for documentation or review.

// - Validate and enhance presentation workflows before publishing.

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

            using (Presentation presentation = new Presentation(inputPath))

            {

                // Ensure each slide has a notes slide and enable slide number visibility on it

                for (int i = 0; i < presentation.Slides.Count; i++)

                {

                    ISlide slide = presentation.Slides[i];

                    INotesSlideManager notesManager = slide.NotesSlideManager;

                    INotesSlide notesSlide = notesManager.NotesSlide;

                    if (notesSlide == null)

                    {

                        notesSlide = notesManager.AddNotesSlide();

                    }



                    IBaseSlideHeaderFooterManager notesHeaderFooter = notesSlide.HeaderFooterManager;

                    notesHeaderFooter.SetSlideNumberVisibility(true);

                }



                // Configure PDF export to include notes pages

                PdfOptions pdfOptions = new PdfOptions();

                pdfOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions()

                {

                    NotesPosition = NotesPositions.BottomFull

                };



                presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);

            }

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

