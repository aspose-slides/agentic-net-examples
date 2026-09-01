// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Configure swfoptions jpegquality from config threshold using C#

//

// Description:

// Demonstrates how to configure SWF export options JPEG quality based on a

// configurable threshold using C# and Aspose.Slides for .NET. The example

// loads a PowerPoint presentation, applies the JPEG quality setting to the

// SwfOptions, and saves the presentation as an SWF file. It also shows how

// to accept command‑line arguments for input, output, and quality threshold.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Configure, SwfOptions,

// JpegQuality, Config, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX files to SWF with custom JPEG quality.

// - Build C# tools for PowerPoint presentation processing with configurable settings.

// - Generate or transform presentations in .NET applications while controlling image quality.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SwfJpegQualityDemo

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            string outputPath = args.Length > 1 ? args[1] : "output.swf";



            // Configuration threshold for JPEG quality

            int qualityThreshold = 80;

            if (args.Length > 2)

            {

                int parsed;

                if (int.TryParse(args[2], out parsed))

                {

                    qualityThreshold = parsed;

                }

            }



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load presentation

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



                // Create SWF options and set JPEG quality based on configuration

                Aspose.Slides.Export.SwfOptions swfOptions = CreateSwfOptionsWithQuality(qualityThreshold);



                // Save presentation as SWF with the configured options

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);



                // Dispose presentation

                presentation.Dispose();



                Console.WriteLine("Presentation saved to SWF with JPEG quality: " + swfOptions.JpegQuality);

            }

            catch (NotSupportedException)

            {

                // Format not supported

                // Comment: format not supported

                Console.WriteLine("The specified file format is not supported.");

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., web service errors)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }



        // Method to create SwfOptions and set JpegQuality based on a threshold

        private static Aspose.Slides.Export.SwfOptions CreateSwfOptionsWithQuality(int threshold)

        {

            Aspose.Slides.Export.SwfOptions options = new Aspose.Slides.Export.SwfOptions();



            // Ensure quality is within 0-100 range

            if (threshold < 0)

            {

                options.JpegQuality = 0;

            }

            else if (threshold > 100)

            {

                options.JpegQuality = 100;

            }

            else

            {

                options.JpegQuality = threshold;

            }



            return options;

        }

    }

}

