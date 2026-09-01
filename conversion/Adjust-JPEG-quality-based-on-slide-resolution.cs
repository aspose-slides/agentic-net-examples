// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Adjust JPEG quality based on slide resolution using C#

//

// Description:

// Demonstrates how to adjust JPEG quality based on slide resolution when

// converting a PowerPoint presentation to SWF using C# and Aspose.Slides for .NET.

// The example shows the required presentation‑processing steps for PPTX files

// and produces the output in a standalone console application. Developers can

// use this pattern to automate PPTX‑to‑SWF workflows, control image quality,

// or integrate presentation conversion logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPEG, Adjust, Jpeg, Quality,

// Based, Presentation Processing, Office Automation, SWF, Conversion

//

// Use Cases:

// - Automate JPEG quality adjustment based on slide resolution during SWF conversion.

// - Build C# tools for PowerPoint to SWF conversion with quality control.

// - Generate or transform PPTX files into SWF in .NET applications.

// - Validate presentation conversion workflows before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace AdjustSwfJpegQuality

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.swf";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load presentation

                Presentation presentation = new Presentation(inputPath);



                // Determine slide resolution (area) to decide JPEG quality

                float slideWidth = presentation.SlideSize.Size.Width;

                float slideHeight = presentation.SlideSize.Size.Height;

                float slideArea = slideWidth * slideHeight;



                // Default JPEG quality

                int jpegQuality = 95;



                // Adjust quality based on resolution

                if (slideArea > 3000f * 2000f) // Very high resolution

                {

                    jpegQuality = 60;

                }

                else if (slideArea > 2000f * 1500f) // High resolution

                {

                    jpegQuality = 80;

                }

                // else keep default quality



                // Configure SWF options with dynamic JPEG quality

                SwfOptions swfOptions = new SwfOptions();

                swfOptions.JpegQuality = jpegQuality;



                // Save presentation as SWF with the configured options

                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

                presentation.Dispose();



                Console.WriteLine("Presentation saved as SWF with JPEG quality: " + jpegQuality);

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The specified format is not supported for conversion.");

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., file access issues)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

