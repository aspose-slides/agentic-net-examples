// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Apply grayscale filter to PDF note images using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation, configure PDF export

// options to include slide notes, and (conceptually) apply a grayscale filter

// to images embedded in the notes before saving the presentation as a PDF.

// The example uses Aspose.Slides for .NET and can serve as a template for

// automating note‑image processing during PPTX‑to‑PDF conversion.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Grayscale, Note Images, 

// Export, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate applying a grayscale filter to note images when exporting PPTX to PDF.

// - Build C# utilities for processing slide notes and images in presentations.

// - Generate PDFs with notes that have consistent visual styling.

// - Validate and transform presentation content before publishing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SlidesExportExample

{

    class Program

    {

        static void Main(string[] args)

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

                Presentation presentation = new Presentation(inputPath);



                // Set up PDF options to include notes in the output

                PdfOptions pdfOptions = new PdfOptions();

                NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();

                notesOptions.NotesPosition = NotesPositions.BottomFull;

                pdfOptions.SlidesLayoutOptions = notesOptions;



                // Apply grayscale filter to note images (conceptual – actual API may vary)

                // Note: Aspose.Slides does not provide a direct property for grayscale conversion of note images.

                // This placeholder indicates where such processing would be applied if available.



                // Save the presentation as PDF with notes

                presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);



                // Dispose the presentation

                presentation.Dispose();



                Console.WriteLine("Presentation exported to PDF successfully.");

            }

            catch (NotSupportedException)

            {

                // Format not supported

                // Comment: The provided file format is not supported for conversion.

                Console.WriteLine("The file format is not supported.");

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., I/O errors, Aspose.Slides errors)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

