// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert PPTX to PDF 80percent quality using C#

//

// Description:

// Demonstrates how to convert a PPTX file to a PDF with JPEG image quality set

// to 80% using C# and Aspose.Slides for .NET. The example loads a PowerPoint

// presentation, configures PDF export options to reduce image quality for a

// smaller file size, and saves the result as a PDF document. This pattern can

// be used to automate PPTX to PDF conversion workflows, integrate presentation

// processing into .NET applications, or generate optimized PDF outputs.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Convert, Pptx, 80Percent,

// Quality, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX files to PDF with reduced image quality.

// - Build C# utilities for PowerPoint presentation processing and export.

// - Generate optimized PDF versions of presentations for distribution.

// - Integrate PPTX to PDF conversion into larger .NET automation pipelines.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ConvertPptxToPdf

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

                Presentation presentation = new Presentation(inputPath);



                // Set PDF options with JPEG quality at 80%

                PdfOptions pdfOptions = new PdfOptions();

                pdfOptions.JpegQuality = 80;



                // Save the presentation as PDF with the specified options

                presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);

            }

            catch (NotSupportedException)

            {

                // Handle unsupported file format

                Console.WriteLine("The file format is not supported.");

            }

            catch (Exception ex)

            {

                // Handle other possible exceptions

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

