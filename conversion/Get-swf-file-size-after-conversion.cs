// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Get SWF file size after conversion using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation to SWF format using

// Aspose.Slides for .NET and retrieve the resulting file size. The example

// includes basic validation of the input file, performs the conversion, and

// outputs the SWF file size in bytes. This pattern can be used in console

// applications or automated workflows that require size verification after

// conversion.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SWF, File Size, Conversion,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate retrieval of SWF file size after converting PPTX files.

// - Build C# utilities for PowerPoint to SWF conversion with size validation.

// - Integrate presentation conversion steps into .NET applications.

// - Verify output file sizes before publishing or further processing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SwfConversionApp

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = "input.pptx";

            string outputPath = "output.swf";



            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist.");

                return;

            }



            try

            {

                long swfSize = ConvertToSwfAndGetSize(inputPath, outputPath);

                Console.WriteLine("SWF file size: " + swfSize + " bytes");

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The file format is not supported for conversion.");

            }

            catch (Exception ex)

            {

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }



        static long ConvertToSwfAndGetSize(string inputPath, string outputPath)

        {

            // Load presentation

            Presentation presentation = new Presentation(inputPath);

            // Set SWF options if needed

            SwfOptions swfOptions = new SwfOptions();

            // Save as SWF

            presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

            // Ensure presentation is saved before getting file size

            presentation.Dispose();



            // Get file size

            FileInfo fileInfo = new FileInfo(outputPath);

            return fileInfo.Length;

        }

    }

}

