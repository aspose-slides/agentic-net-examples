// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Enable compression for SWF and verify player using C#

//

// Description:

// Demonstrates how to enable compression when converting a PowerPoint

// presentation to SWF format and how to verify the generated SWF file using

// Aspose.Slides for .NET. The example loads a PPTX file, sets the

// SwfOptions.Compressed property, saves the presentation as a compressed SWF,

// and checks that the output file exists.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Compression, Aspose.Slides for .NET, Presentation

// Conversion, Verify, Output Validation

//

// Use Cases:

// - Convert PPTX presentations to compressed SWF for web delivery.

// - Automate verification of SWF output in CI pipelines.

// - Build .NET utilities that prepare presentations for Flash Player.

// - Ensure SWF files are generated with compression to reduce size.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Determine input file path

        string inputPath;

        if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))

        {

            inputPath = args[0];

        }

        else

        {

            inputPath = "input.pptx"; // default input file

        }



        // Verify input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        // Prepare output SWF file path

        string outputDirectory = Path.GetDirectoryName(inputPath) ?? "";

        string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".swf";

        string outputPath = Path.Combine(outputDirectory, outputFileName);



        try

        {

            // Load presentation

            Presentation presentation = new Presentation(inputPath);



            // Configure SWF options with compression enabled

            SwfOptions swfOptions = new SwfOptions();

            swfOptions.Compressed = true; // enable compression



            // Save as SWF

            presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

            presentation.Dispose();



            // Verify that the SWF file was created

            if (File.Exists(outputPath))

            {

                Console.WriteLine("SWF file created successfully: " + outputPath);

                // Manual verification: open the file in Adobe Flash Player

            }

            else

            {

                Console.WriteLine("Failed to create SWF file.");

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

            Console.WriteLine("The file format is not supported for SWF conversion.");

        }

        catch (Exception ex)

        {

            // General error handling

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

