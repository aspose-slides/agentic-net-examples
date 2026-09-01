// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load PPTX show hidden slides compressed SWF using C#

//

// Description:

// Demonstrates how to load a PPTX file, include hidden slides, and save it as a

// compressed SWF file using C# and Aspose.Slides for .NET. The example covers

// file existence checking, presentation loading, SWF option configuration,

// and error handling in a console application.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Load, Show Hidden Slides,

// Compressed SWF, Presentation Processing, Office Automation

//

// Use Cases:

// - Convert PPTX presentations to compressed SWF while preserving hidden slides.

// - Build automation tools for PowerPoint to SWF conversion in .NET.

// - Integrate presentation conversion into larger document processing pipelines.

// - Validate and test SWF output generation from PPTX sources.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace AsposeSlidesExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.swf";



            // Check if the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                Presentation presentation = new Presentation(inputPath);



                // Configure SWF options

                SwfOptions swfOptions = new SwfOptions();

                swfOptions.ShowHiddenSlides = true;               // Include hidden slides

                swfOptions.DefaultRegularFont = "Arial";          // Set default font

                // swfOptions.Compressed is true by default (compressed SWF)



                // Save as compressed SWF with the specified options

                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);



                // Dispose the presentation after saving

                presentation.Dispose();

            }

            catch (NotSupportedException ex)

            {

                // Format not supported

                Console.WriteLine("Format not supported: " + ex.Message);

                // format not supported

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

