// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Determine swfoptions compressed from disk space using C#

//

// Description:

// Demonstrates how to determine whether to enable compression for SWF output

// based on available disk space using C# and Aspose.Slides for .NET. The example

// loads a PowerPoint presentation, checks free space on the target drive, sets

// the SwfOptions.Compressed property accordingly, and saves the presentation as

// an SWF file. This pattern helps developers create disk‑space‑aware conversion

// utilities for PowerPoint files.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Determine, SwfOptions, 

// Compressed, Disk Space, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate SWF conversion with compression toggled based on free disk space.

// - Build C# tools for PowerPoint presentation processing that adapt to storage constraints.

// - Generate or transform PPTX files to SWF in .NET applications while managing resource usage.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Input and output file paths

        string inputPath = "input.pptx";

        string outputPath = "output.swf";



        // Override paths if provided via command line arguments

        if (args.Length >= 2)

        {

            inputPath = args[0];

            outputPath = args[1];

        }



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



            // Ensure output directory exists

            string outputDirectory = Path.GetDirectoryName(outputPath);

            if (string.IsNullOrEmpty(outputDirectory))

            {

                outputDirectory = Directory.GetCurrentDirectory();

                outputPath = Path.Combine(outputDirectory, outputPath);

            }



            if (!Directory.Exists(outputDirectory))

            {

                Directory.CreateDirectory(outputDirectory);

            }



            // Determine available free space on the drive where the output will be saved

            DriveInfo driveInfo = new DriveInfo(Path.GetPathRoot(outputDirectory));

            long freeSpaceBytes = driveInfo.AvailableFreeSpace;



            // Configure SWF options based on free disk space

            SwfOptions swfOptions = new SwfOptions();

            const long lowSpaceThreshold = 100L * 1024 * 1024; // 100 MB



            if (freeSpaceBytes < lowSpaceThreshold)

            {

                swfOptions.Compressed = false;

                Console.WriteLine("Low disk space detected. Compression disabled.");

            }

            else

            {

                swfOptions.Compressed = true;

                Console.WriteLine("Sufficient disk space. Compression enabled.");

            }



            // Save the presentation as SWF with the configured options

            presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

            presentation.Dispose();



            Console.WriteLine("Presentation saved to: " + outputPath);

        }

        catch (NotSupportedException ex)

        {

            // Handle unsupported file format

            Console.WriteLine("File format not supported: " + ex.Message);

        }

        catch (Exception ex)

        {

            // General exception handling

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

