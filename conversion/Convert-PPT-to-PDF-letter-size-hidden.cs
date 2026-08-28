// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert PPT to PDF (Letter size) including hidden slides using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation (PPTX) to a PDF file

// with Letter page size (8.5 x 11 inches) while preserving hidden slides using

// Aspose.Slides for .NET. The example loads a presentation, sets the slide

// dimensions, configures PDF options to show hidden slides, and saves the result.

// This pattern can be used in console applications or automated workflows.

//

// Keywords:

// C#, Aspose.Slides, PowerPoint, PPTX, PDF, Letter size, Hidden slides, Convert,

// Presentation processing, .NET

//

// Use Cases:

// - Convert PPTX files to PDF with specific page dimensions.

// - Include hidden slides in the generated PDF.

// - Automate document conversion in batch processing or CI pipelines.

// - Integrate PowerPoint to PDF conversion into .NET services or tools.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides.Export;



namespace SlideToPdf

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.pdf";



            // Check if the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist.");

                return;

            }



            try

            {

                // Load the presentation

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

                {

                    // Set slide size to Letter format (8.5 x 11 inches) with EnsureFit scaling

                    presentation.SlideSize.SetSize(612f, 792f, Aspose.Slides.SlideSizeScaleType.EnsureFit);



                    // Configure PDF options to include hidden slides

                    PdfOptions pdfOptions = new PdfOptions();

                    pdfOptions.ShowHiddenSlides = true;



                    // Save the presentation as PDF

                    presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);

                }

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

}

