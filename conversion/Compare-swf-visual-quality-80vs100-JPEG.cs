// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Compare SWF visual quality 80 vs 100 JPEG using C#

//

// Description:

// Demonstrates how to generate two SWF files from a PowerPoint presentation

// using different JPEG quality settings (80 and 100) with Aspose.Slides for .NET,

// and compares their file sizes as an indicator of visual quality. The example

// shows loading a PPTX, saving as SWF with specific JPEG quality, and reporting

// the results in a console application.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SWF, JPEG, Quality, 80, 100,

// Visual Quality Comparison, Presentation Conversion, Office Automation

//

// Use Cases:

// - Evaluate impact of JPEG quality settings on SWF output size and visual fidelity.

// - Automate generation of SWF files with different quality levels.

// - Integrate quality comparison logic into .NET presentation processing tools.

// - Validate conversion settings before publishing presentations.

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

            // Input presentation path

            string inputPath = "input.pptx";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            // Output SWF file paths

            string outputSwf80 = "output_quality_80.swf";

            string outputSwf100 = "output_quality_100.swf";



            try

            {

                // Load presentation

                using (Presentation presentation = new Presentation(inputPath))

                {

                    // Save with JPEG quality 80

                    SwfOptions options80 = new SwfOptions();

                    options80.JpegQuality = 80;

                    presentation.Save(outputSwf80, SaveFormat.Swf, options80);



                    // Save with JPEG quality 100

                    SwfOptions options100 = new SwfOptions();

                    options100.JpegQuality = 100;

                    presentation.Save(outputSwf100, SaveFormat.Swf, options100);

                }



                // Compare file sizes as a proxy for visual quality

                FileInfo info80 = new FileInfo(outputSwf80);

                FileInfo info100 = new FileInfo(outputSwf100);



                long size80 = info80.Length;

                long size100 = info100.Length;



                Console.WriteLine("SWF file with JPEG quality 80 size: " + size80 + " bytes");

                Console.WriteLine("SWF file with JPEG quality 100 size: " + size100 + " bytes");



                if (size100 > size80)

                {

                    Console.WriteLine("Higher JPEG quality results in larger file size, indicating higher visual fidelity.");

                }

                else if (size100 == size80)

                {

                    Console.WriteLine("File sizes are equal; visual quality difference may be negligible.");

                }

                else

                {

                    Console.WriteLine("Unexpected: higher quality file is smaller.");

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The provided file format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

