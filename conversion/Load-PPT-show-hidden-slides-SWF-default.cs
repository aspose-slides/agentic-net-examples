// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load PPT show hidden slides SWF default using C#

//

// Description:

// Demonstrates how to load a PPTX file, include hidden slides, and convert it

// to SWF format using default compression with Aspose.Slides for .NET. The

// example performs the necessary presentation-processing steps and outputs a

// standalone console application. Developers can use this pattern to automate

// PPTX to SWF conversion while preserving hidden slides.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Load, Show Hidden Slides,

// Conversion, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX files to SWF while retaining hidden slides.

// - Build C# tools for PowerPoint presentation processing and export.

// - Generate SWF assets from presentations in .NET applications.

// - Validate presentation workflows before publishing or integration.

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

                swfOptions.ShowHiddenSlides = true; // Include hidden slides



                // Save the presentation as SWF with default compression

                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);



                // Dispose the presentation

                presentation.Dispose();



                Console.WriteLine("Presentation converted to SWF successfully.");

            }

            catch (Exception ex)

            {

                // Handle format not supported or other exceptions

                // Format not supported

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

