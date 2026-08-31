// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Embed all fonts and generate PDF using C#

//

// Description:

// Demonstrates how to embed all fonts from a PowerPoint presentation and

// generate a PDF using C# and Aspose.Slides for .NET. The example loads a PPTX

// file, configures PDF export options to embed full fonts, and saves the result

// as a PDF document. This pattern can be used in console applications or

// automation scripts for presentation processing.

//

// Keywords:

// C#, Aspose.Slides, PDF, Embed Fonts, PowerPoint, PPTX, Presentation Export,

// .NET, Office Automation

//

// Use Cases:

// - Convert PPTX files to PDF with all fonts embedded for reliable rendering.

// - Build command‑line tools that ensure PDF output preserves original typography.

// - Automate batch processing of presentations for publishing or archiving.

// - Validate font embedding in generated PDFs before distribution.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace FontEmbeddingPdfExample

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

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



                // Configure PDF options to embed all fonts

                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();

                pdfOptions.EmbedFullFonts = true;



                // Save the presentation as PDF with embedded fonts

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);



                // Dispose the presentation

                presentation.Dispose();



                Console.WriteLine("PDF saved successfully with embedded fonts.");

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other errors

                Console.WriteLine("An error occurred: " + ex.Message);

                // Format not supported comment

                // The provided file format may not be supported by Aspose.Slides.

            }

        }

    }

}

