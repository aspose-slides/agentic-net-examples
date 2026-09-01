// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert ODP to PDF all slides using C#

//

// Description:

// Demonstrates how to convert an ODP (OpenDocument Presentation) file to a

// PDF document containing all slides using C# and Aspose.Slides for .NET.

// The example loads an ODP presentation, saves it as PDF with default

// settings, and includes basic error handling. This pattern can be used to

// automate ODP to PDF conversions in .NET applications.

//

// Keywords:

// C#, ODP, PDF, Aspose.Slides for .NET, Convert, Slides, Presentation Processing,

// Office Automation, OpenDocument

//

// Use Cases:

// - Automate conversion of ODP presentations to PDF.

// - Build C# utilities for batch processing of OpenDocument slides.

// - Integrate ODP to PDF conversion into .NET workflows.

// - Validate ODP files before publishing or distribution.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace OdpToPdfConverter

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.odp");

            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");



            // Verify that the input ODP file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the ODP presentation

                using (Presentation pres = new Presentation(inputPath))

                {

                    // Save all slides to PDF using default settings

                    pres.Save(outputPath, SaveFormat.Pdf);

                }



                Console.WriteLine("Conversion completed successfully.");

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The specified format is not supported for conversion.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

