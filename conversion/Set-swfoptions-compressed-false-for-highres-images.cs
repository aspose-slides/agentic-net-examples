// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set swfoptions compressed false for highres images using C#

//

// Description:

// Demonstrates how to disable SWF compression to retain high‑resolution images 

// when converting a PowerPoint presentation to SWF using Aspose.Slides for .NET. 

// The example loads a PPTX file, configures SwfOptions.Compressed = false, and 

// saves the result as a SWF file in a console application.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SWF, SwfOptions, Compressed, False, 

// High‑Resolution Images, Presentation Conversion, Office Automation

//

// Use Cases:

// - Convert PPTX to SWF without losing image quality.

// - Build .NET utilities that require high‑resolution graphics in SWF output.

// - Automate batch conversion of presentations while preserving image fidelity.

// - Integrate SWF export into larger document processing pipelines.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SwfConversionExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.swf";



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



                // Configure SWF options: disable compression to preserve image quality

                Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();

                swfOptions.Compressed = false;



                // Save the presentation as SWF with the specified options

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);



                // Dispose the presentation object

                presentation.Dispose();

            }

            catch (NotSupportedException)

            {

                // Handle unsupported format exception

                Console.WriteLine("The specified format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

