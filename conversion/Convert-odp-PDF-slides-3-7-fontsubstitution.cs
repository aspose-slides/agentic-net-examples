// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert ODP to PDF slides 3-7 with font substitution using C#

//

// Description:

// Demonstrates how to convert an ODP presentation to a PDF document while

// selecting slides 3 through 7 and applying font substitution using Aspose.Slides

// for .NET. The example loads an ODP file, sets a default regular font for missing

// fonts, defines the slide range, and saves the selected slides as a PDF.

//

// Keywords:

// C#, ODP, PDF, Slides, Font substitution, Aspose.Slides for .NET, Presentation conversion, PowerPoint automation

//

// Use Cases:

// - Convert specific slide ranges from ODP to PDF with fallback fonts.

// - Automate batch processing of ODP files in .NET applications.

// - Ensure consistent rendering when original fonts are unavailable.

// - Integrate ODP to PDF conversion into document management workflows.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ConvertOdpToPdf

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = "input.odp";

            string outputPath = "output.pdf";



            // Check if the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the ODP presentation

                using (Presentation presentation = new Presentation(inputPath))

                {

                    // Enable font substitution by setting a default regular font

                    PdfOptions pdfOptions = new PdfOptions();

                    pdfOptions.DefaultRegularFont = "Arial";



                    // Define the slide range (3 to 7, 1‑based indexing)

                    int[] slideIndices = new int[] { 3, 4, 5, 6, 7 };



                    // Save selected slides as PDF

                    presentation.Save(outputPath, slideIndices, SaveFormat.Pdf, pdfOptions);

                }



                Console.WriteLine("Conversion completed successfully.");

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other errors

                Console.WriteLine("An error occurred: " + ex.Message);

                // Comment: format not supported

            }

        }

    }

}

