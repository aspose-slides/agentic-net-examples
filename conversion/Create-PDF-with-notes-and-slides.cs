// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create PDF with notes and slides using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation to a PDF that includes

// both the slide images and their associated speaker notes using Aspose.Slides for .NET.

// The example loads a PPTX file, configures PDF export options to place notes at the

// bottom of each slide, and saves the result as a PDF document.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Speaker Notes, Slides, 

// Presentation Conversion, Office Automation

//

// Use Cases:

// - Generate PDFs that combine slide visuals with speaker notes for distribution.

// - Automate creation of handouts that include presentation content and annotations.

// - Build .NET tools for converting PPTX files to PDF with custom layout options.

// - Integrate PowerPoint to PDF conversion into larger document processing pipelines.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace AsposeSlidesExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input presentation path

            string inputPath = "input.pptx";

            // Output PDF path

            string outputPath = "output.pdf";



            // Check if the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                using (Presentation presentation = new Presentation(inputPath))

                {

                    // Configure PDF options to include both slides and speaker notes

                    PdfOptions pdfOptions = new PdfOptions();

                    pdfOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions

                    {

                        NotesPosition = NotesPositions.BottomFull

                    };



                    // Save the presentation as PDF with the specified layout options

                    presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);

                }



                Console.WriteLine("PDF created successfully: " + outputPath);

            }

            catch (PptxUnsupportedFormatException)

            {

                // Handle unsupported file format

                Console.WriteLine("The provided file format is not supported for conversion.");

            }

            catch (Exception ex)

            {

                // General exception handling (e.g., I/O errors, Aspose.Slides internal errors)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

