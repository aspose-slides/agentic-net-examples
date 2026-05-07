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