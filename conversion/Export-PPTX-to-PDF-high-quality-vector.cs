// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX to PDF high quality vector using C#

//

// Description:

// Demonstrates how to export a PPTX file to a high‑quality vector PDF using C#

// and Aspose.Slides for .NET. The example loads a presentation, configures PDF

// options to retain vector graphics and maximum image quality, and saves the

// result as a PDF file. This pattern can be used in console utilities or

// automated workflows that require precise PDF rendering of PowerPoint content.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Export, High, Quality,

// Vector, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX to high‑quality vector PDF.

// - Build .NET tools for preserving vector graphics when exporting presentations.

// - Integrate PPTX to PDF conversion into server‑side or desktop applications.

// - Ensure PDF output meets publishing standards for graphics fidelity.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ExportPptxToPdf

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

                using (Presentation presentation = new Presentation(inputPath))

                {

                    // Configure PDF options for high quality and vector graphics retention

                    PdfOptions pdfOptions = new PdfOptions();

                    pdfOptions.SaveMetafilesAsPng = false; // Preserve metafiles as vectors

                    pdfOptions.JpegQuality = 100; // Maximum JPEG quality for raster images



                    // Save the presentation as PDF using the configured options

                    presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);

                }



                Console.WriteLine("Presentation successfully exported to PDF: " + outputPath);

            }

            catch (NotSupportedException)

            {

                // Handle unsupported file format

                Console.WriteLine("The file format is not supported for conversion.");

            }

            catch (Exception ex)

            {

                // Handle other exceptions

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

