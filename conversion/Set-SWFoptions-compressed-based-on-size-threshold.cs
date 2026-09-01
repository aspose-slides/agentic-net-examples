// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set SWFoptions compressed based on size threshold using C#

//

// Description:

// Demonstrates how to set the SwfOptions.Compressed property based on a

// presentation file size threshold using C# and Aspose.Slides for .NET.

// The example loads a PPTX file, checks its size, configures compression

// accordingly, and saves the presentation as an SWF file.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SwfOptions, Compression, Size Threshold, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conditional SWF compression when converting PPTX files.

// - Build C# utilities for PowerPoint to SWF conversion with size‑based logic.

// - Generate SWF output with appropriate compression for downstream consumption.

// - Validate conversion settings in automated presentation workflows.

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

            // Define input, output and size threshold (in bytes)

            string inputPath = "input.pptx";

            string outputPath = "output.swf";

            long sizeThreshold = 5 * 1024 * 1024; // 5 MB



            try

            {

                SetSwfCompression(inputPath, outputPath, sizeThreshold);

            }

            catch (FileNotFoundException ex)

            {

                Console.WriteLine("File not found: " + ex.FileName);

            }

            catch (NotSupportedException ex)

            {

                // Format not supported

                Console.WriteLine("Format not supported: " + ex.Message);

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }



        static void SetSwfCompression(string inputPath, string outputPath, long sizeThreshold)

        {

            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                throw new FileNotFoundException("Input file does not exist.", inputPath);

            }



            // Get file size

            FileInfo fileInfo = new FileInfo(inputPath);

            long fileSize = fileInfo.Length;



            // Load presentation

            Presentation presentation = new Presentation(inputPath);



            // Create SWF options

            SwfOptions swfOptions = new SwfOptions();



            // Set compression based on size threshold

            if (fileSize > sizeThreshold)

            {

                swfOptions.Compressed = false;

            }

            else

            {

                swfOptions.Compressed = true;

            }



            // Save as SWF

            presentation.Save(outputPath, SaveFormat.Swf, swfOptions);



            // Dispose presentation

            presentation.Dispose();

        }

    }

}

