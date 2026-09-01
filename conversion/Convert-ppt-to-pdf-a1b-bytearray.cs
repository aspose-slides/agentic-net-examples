// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert ppt to pdf a1b bytearray using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation (PPTX) to a PDF/A‑1b

// compliant PDF using a byte array and Aspose.Slides for .NET. The example reads

// the input file into memory, loads it via a MemoryStream, applies PDF/A‑1b

// compliance settings, and saves the result as a PDF file. This pattern can be

// used in console applications or services that need to process presentations

// without relying on file‑system paths for the source document.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF/A-1b, PDF, Bytearray,

// Presentation Processing, Office Automation, Convert

//

// Use Cases:

// - Automate conversion of PPTX files to PDF/A‑1b compliant PDFs.

// - Build .NET tools that process PowerPoint presentations from byte arrays.

// - Integrate presentation conversion into server‑side or cloud services.

// - Validate and archive presentations in a PDF/A‑1b format for long‑term storage.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace Example

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input PPT file path and output PDF file path

            string inputFilePath = "input.pptx";

            string outputFilePath = "output.pdf";



            // Verify that the input file exists

            if (!File.Exists(inputFilePath))

            {

                Console.WriteLine("Input file does not exist.");

                return;

            }



            // Read the PPT file into a byte array

            byte[] pptBytes = File.ReadAllBytes(inputFilePath);



            // Load the presentation from the byte array using a memory stream

            using (MemoryStream memoryStream = new MemoryStream(pptBytes))

            {

                try

                {

                    Presentation presentation = new Presentation(memoryStream);



                    // Configure PDF options for PDF/A‑1b compliance (default image quality)

                    PdfOptions pdfOptions = new PdfOptions();

                    pdfOptions.Compliance = PdfCompliance.PdfA1b;



                    // Save the presentation as a PDF file

                    presentation.Save(outputFilePath, SaveFormat.Pdf, pdfOptions);



                    // Dispose the presentation object

                    presentation.Dispose();

                }

                catch (NotSupportedException)

                {

                    // Comment: format not supported

                    Console.WriteLine("The provided format is not supported for conversion.");

                }

                catch (Exception ex)

                {

                    // Handle other exceptions (e.g., I/O errors)

                    Console.WriteLine("An error occurred: " + ex.Message);

                }

            }

        }

    }

}

