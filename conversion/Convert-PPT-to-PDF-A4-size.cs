// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert PPT to PDF A4 size using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation (PPTX) to a PDF file

// with A4 page dimensions using Aspose.Slides for .NET. The example loads a

// presentation, sets the slide size to A4 paper with maximum scaling, and

// saves the result as a PDF. This pattern can be used in console applications

// to automate PPTX to PDF conversion with specific page sizing.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, A4, Convert, Size,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX files to PDF with A4 page size.

// - Build .NET tools for batch processing of PowerPoint presentations.

// - Generate PDF reports from slides with standardized dimensions.

// - Integrate slide-to-PDF conversion into larger document workflows.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

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

                    // Set slide size to A4 paper and maximize content scaling

                    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize);



                    // Create PDF options (customize as needed)

                    PdfOptions pdfOptions = new PdfOptions();



                    // Save the presentation as PDF with the specified options

                    presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);

                }



                Console.WriteLine("Presentation successfully converted to PDF: " + outputPath);

            }

            catch (NotSupportedException)

            {

                // Handle unsupported format exception

                Console.WriteLine("The file format is not supported for conversion.");

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., external URL issues)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

