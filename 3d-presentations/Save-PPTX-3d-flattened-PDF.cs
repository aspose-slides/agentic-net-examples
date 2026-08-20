// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Save PPTX 3d flattened PDF using C#

//

// Description:

// Demonstrates how to load a PPTX file, configure PDF export options to flatten

// 3‑D objects into static raster images, and save the result as a PDF using

// Aspose.Slides for .NET. The example includes basic file existence checks and

// exception handling suitable for console applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Save, Flattened 3D, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Convert PPTX presentations containing 3‑D models to PDF with flattened graphics.

// - Automate generation of PDF reports from PowerPoint files in .NET environments.

// - Ensure compatibility of exported PDFs across viewers by rasterizing 3‑D content.

// - Integrate PPTX to PDF conversion into build pipelines or server‑side services.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace AsposeSlidesPdfExport

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");

            string outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");



            // Check if the input file exists

            if (!File.Exists(inputFilePath))

            {

                Console.WriteLine("Input file does not exist: " + inputFilePath);

                return;

            }



            try

            {

                // Load the presentation

                Presentation presentation = new Presentation(inputFilePath);



                // Configure PDF options to flatten 3D objects into static images

                PdfOptions pdfOptions = new PdfOptions

                {

                    SaveMetafilesAsPng = true, // Rasterize metafiles (including 3D objects)

                    IncludeOleData = false     // Do not include OLE data

                };



                // Save the presentation as PDF

                presentation.Save(outputFilePath, SaveFormat.Pdf, pdfOptions);



                // Dispose the presentation

                presentation.Dispose();



                Console.WriteLine("Presentation successfully saved as PDF: " + outputFilePath);

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The file format is not supported for conversion.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

