// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert PPTX to PDF 11x8.5in 85percent quality using C#

//

// Description:

// Demonstrates how to convert a PPTX file to a PDF with a custom slide size of

// 11 x 8.5 inches and JPEG image quality set to 85% using Aspose.Slides for .NET.

// The example loads a presentation, adjusts the slide dimensions, configures

// PDF export options, and saves the result as a PDF file.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Convert, 11x8.5in, 85Percent,

// SlideSize, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX presentations to PDF with specific page size.

// - Generate high‑quality PDFs for printing or distribution.

// - Integrate slide size and image quality settings into .NET document workflows.

// - Validate and process PowerPoint files before publishing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides.Export;



namespace ConvertPptxToPdf

{

    class Program

    {

        static void Main(string[] args)

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

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

                {

                    // Set custom slide size to 11 x 8.5 inches (792 x 612 points)

                    presentation.SlideSize.SetSize(792F, 612F, Aspose.Slides.SlideSizeScaleType.EnsureFit);



                    // Configure PDF options with JPEG quality 85%

                    PdfOptions pdfOptions = new PdfOptions();

                    pdfOptions.JpegQuality = 85;



                    // Save the presentation as PDF

                    presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);

                }



                Console.WriteLine("Conversion completed successfully.");

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The specified file format is not supported for conversion.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

