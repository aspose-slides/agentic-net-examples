using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.swf";

        // Allow overriding paths via command‑line arguments
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
            // Determine the drive that will contain the output file
            string outputDirectory = Path.GetDirectoryName(Path.GetFullPath(outputPath));
            if (string.IsNullOrEmpty(outputDirectory))
            {
                outputDirectory = Directory.GetCurrentDirectory();
            }
            DriveInfo driveInfo = new DriveInfo(Path.GetPathRoot(outputDirectory));
            long freeSpaceBytes = driveInfo.AvailableFreeSpace;

            // Threshold for enabling compression (e.g., 100 MB)
            const long thresholdBytes = 100L * 1024 * 1024;

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Configure SWF export options based on available disk space
            SwfOptions swfOptions = new SwfOptions();
            if (freeSpaceBytes < thresholdBytes)
            {
                swfOptions.Compressed = false;
                Console.WriteLine("Low disk space detected. Compression disabled.");
            }
            else
            {
                swfOptions.Compressed = true;
                Console.WriteLine("Sufficient disk space. Compression enabled.");
            }

            // Save the presentation as SWF using the configured options
            presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}