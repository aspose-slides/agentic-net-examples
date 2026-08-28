// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load ODP, set JPEG quality to 50, and save as SWF using C#

//

// Description:

// Demonstrates how to load an ODP presentation, configure JPEG quality to 50,

// and save the presentation as an SWF file using Aspose.Slides for .NET. The

// example includes file existence checking, exception handling, and proper

// disposal of resources. This pattern can be used in console applications to

// convert OpenDocument presentations to Flash format with specific image

// compression settings.

//

// Keywords:

// C#, Aspose.Slides, ODP, SWF, JPEG quality, Presentation conversion, PowerPoint,

// OpenDocument, Image compression, SaveFormat.Swf

//

// Use Cases:

// - Convert ODP files to SWF with controlled JPEG compression.

// - Build automated tools for batch conversion of presentations.

// - Integrate ODP to SWF conversion into .NET workflows.

// - Adjust image quality during format conversion for size optimization.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SlideConversion

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputPath = "input.odp";

            string outputPath = "output.swf";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the ODP presentation

                Presentation presentation = new Presentation(inputPath);



                // Configure SWF options with JPEG quality set to 50

                SwfOptions swfOptions = new SwfOptions();

                swfOptions.JpegQuality = 50;



                // Save the presentation as SWF using the configured options

                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);



                // Dispose the presentation object

                presentation.Dispose();



                Console.WriteLine("Presentation successfully saved as SWF.");

            }

            catch (NotSupportedException)

            {

                // Format not supported

                // The ODP format may not be supported for saving as SWF

                Console.WriteLine("The specified format is not supported for this operation.");

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., file access issues)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

