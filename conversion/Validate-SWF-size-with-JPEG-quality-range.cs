// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Validate SWF size with JPEG quality range using C#

//

// Description:

// Demonstrates how to validate SWF size with JPEG quality range using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPEG, Validate, Size, Jpeg, 

// Quality, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate validate SWF size with JPEG quality range.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SwfSizeValidation

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.swf";



            // Desired JPEG quality for SWF conversion

            int jpegQuality = 80;



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                Presentation presentation = new Presentation(inputPath);



                // Configure SWF options with the selected JPEG quality

                SwfOptions swfOptions = new SwfOptions();

                swfOptions.JpegQuality = jpegQuality;



                // Save the presentation as SWF

                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);



                // Validate the generated SWF file size against an expected range

                FileInfo swfInfo = new FileInfo(outputPath);

                long fileSize = swfInfo.Length;



                // Example expected size range calculation based on JPEG quality

                long expectedMin = jpegQuality * 1000L;   // Minimum expected size in bytes

                long expectedMax = jpegQuality * 2000L;  // Maximum expected size in bytes



                if (fileSize >= expectedMin && fileSize <= expectedMax)

                {

                    Console.WriteLine("SWF file size is within the expected range.");

                }

                else

                {

                    Console.WriteLine("SWF file size is outside the expected range.");

                }



                // Clean up

                presentation.Dispose();

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The specified file format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

