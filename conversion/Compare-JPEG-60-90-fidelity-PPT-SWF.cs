// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Compare JPEG 60 90 fidelity PPT SWF using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation to SWF format with

// different JPEG quality settings (60 and 90) using Aspose.Slides for .NET.

// The example loads a PPTX file, saves two SWF files with specified JPEG

// qualities, and can be used to compare visual fidelity between the outputs.

// This pattern helps developers evaluate image compression impact in SWF

// conversions.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, JPEG Quality, Image Compression,

// Fidelity Comparison, Presentation Conversion, Office Automation

//

// Use Cases:

// - Compare visual quality of SWF files generated with different JPEG settings.

// - Assess impact of JPEG compression on PowerPoint to SWF conversion.

// - Build tools for automated quality testing of presentation exports.

// - Generate SWF files with specific image quality requirements.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SwfQualityComparison

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input PowerPoint file path

            string inputPath = "input.pptx";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                Presentation presentation = new Presentation(inputPath);



                // Save with JPEG quality 60

                SwfOptions optionsQuality60 = new SwfOptions();

                optionsQuality60.JpegQuality = 60;

                string outputPath60 = "output_quality60.swf";

                presentation.Save(outputPath60, SaveFormat.Swf, optionsQuality60);



                // Save with JPEG quality 90

                SwfOptions optionsQuality90 = new SwfOptions();

                optionsQuality90.JpegQuality = 90;

                string outputPath90 = "output_quality90.swf";

                presentation.Save(outputPath90, SaveFormat.Swf, optionsQuality90);



                // Dispose the presentation

                presentation.Dispose();

            }

            catch (NotSupportedException)

            {

                // Format not supported

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

