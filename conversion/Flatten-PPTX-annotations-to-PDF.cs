// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Flatten PPTX annotations to PDF using C#

//

// Description:

// Demonstrates how to flatten annotations in a PPTX file and export it to PDF

// using C# and Aspose.Slides for .NET. The example loads a PowerPoint presentation,

// applies default PDF options that flatten annotations, and saves the result as a PDF.

// This pattern can be used to automate PPTX annotation flattening, integrate

// presentation processing into .NET applications, or prepare files for distribution.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Flatten, Annotations,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate flattening of PPTX annotations to PDF.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Prepare presentation files for publishing or archival with annotations flattened.

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



                // Create PDF options (default options flatten annotations)

                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();



                // Save the presentation as PDF with the specified options

                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);



                // Release resources

                pres.Dispose();



                Console.WriteLine("Presentation exported to PDF successfully.");

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The file format is not supported.");

                // format not supported

            }

            catch (Exception ex)

            {

                // General error handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

