// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX to PDF with hyperlinks using C#

//

// Description:

// Demonstrates how to export a PPTX file to PDF while preserving hyperlinks

// using C# and Aspose.Slides for .NET. The example loads a PowerPoint presentation,

// saves it as a PDF (hyperlinks are retained by default), and handles common

// errors such as missing input files or unsupported formats.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Export, Hyperlinks,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX presentations to PDF with active hyperlinks.

// - Build .NET tools for batch processing of PowerPoint files.

// - Integrate PDF export functionality into existing C# applications.

// - Validate that hyperlinks remain functional after conversion.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides.Export;



namespace MyApp

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.pdf";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



                // Save as PDF preserving hyperlinks (default behavior)

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);



                // Release resources

                presentation.Dispose();



                Console.WriteLine("Presentation successfully saved as PDF.");

            }

            catch (NotSupportedException ex)

            {

                // Format not supported

                Console.WriteLine("The file format is not supported: " + ex.Message);

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., external URL issues)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

