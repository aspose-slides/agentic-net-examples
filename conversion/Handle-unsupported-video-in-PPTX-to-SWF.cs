// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Handle unsupported video in PPTX to SWF using C#

//

// Description:

// Demonstrates how to convert a PowerPoint PPTX file to SWF while handling

// unsupported video formats using Aspose.Slides for .NET. The example loads a

// presentation, attempts conversion, and catches specific exceptions related

// to unsupported video or format issues.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Unsupported Video, 

// Conversion, Presentation Processing, Office Automation

//

// Use Cases:

// - Convert PPTX presentations to SWF when videos may be unsupported.

// - Build .NET utilities that gracefully handle video conversion errors.

// - Automate batch processing of presentations with robust error handling.

// - Integrate presentation conversion into larger .NET workflows.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace VideoToSwfConverter

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.swf";



            // Check if the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            // Load the presentation and convert to SWF with error handling

            try

            {

                // Load presentation

                Presentation presentation = new Presentation(inputPath);



                // Create SWF options (default options are sufficient for this example)

                SwfOptions swfOptions = new SwfOptions();



                // Save presentation as SWF

                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);



                // Dispose presentation before exiting

                presentation.Dispose();



                Console.WriteLine("Conversion completed successfully.");

            }

            catch (PptUnsupportedFormatException)

            {

                // Format not supported for PPT files

                Console.WriteLine("The presentation format is not supported for conversion to SWF.");

            }

            catch (PptxUnsupportedFormatException)

            {

                // Format not supported for PPTX files

                Console.WriteLine("The presentation format is not supported for conversion to SWF.");

            }

            catch (Exception ex)

            {

                // General exception handling (e.g., issues with embedded videos)

                Console.WriteLine("An error occurred during conversion: " + ex.Message);

            }

        }

    }

}

