// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load PPTX and convert to PDF default using C#

//

// Description:

// Demonstrates how to load a PPTX file and convert it to a PDF document using

// the default conversion settings of Aspose.Slides for .NET. The example

// includes basic file existence checking, exception handling, and proper

// disposal of the Presentation object in a console application.

//

// Keywords:

// C#, PowerPoint, PPTX, PDF, Aspose.Slides for .NET, Load, Convert, Default,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PowerPoint presentations to PDF with default settings.

// - Build command‑line tools for batch PPTX‑to‑PDF conversion.

// - Integrate simple presentation conversion into .NET applications.

// - Validate PPTX files before publishing by generating PDF previews.

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



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the PPTX presentation

                Presentation presentation = new Presentation(inputPath);



                // Save the presentation as PDF using default options

                presentation.Save(outputPath, SaveFormat.Pdf);



                // Dispose the presentation object

                presentation.Dispose();



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

