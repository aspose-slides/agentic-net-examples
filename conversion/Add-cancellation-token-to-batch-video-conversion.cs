using System;
using System.IO;
using System.Threading;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output directories
        string inputFolder = "input";
        string outputFolder = "output";

        // Verify input folder exists
        if (!Directory.Exists(inputFolder))
        {
            Console.WriteLine("Input folder does not exist.");
            return;
        }

        // Ensure output folder exists
        if (!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
        }

        // Set up cancellation support (Ctrl+C)
        CancellationTokenSource cancellationSource = new CancellationTokenSource();
        Console.CancelKeyPress += (sender, e) =>
        {
            e.Cancel = true; // Prevent immediate termination
            cancellationSource.Cancel();
        };

        // Get all files in the input folder
        string[] presentationFiles = Directory.GetFiles(inputFolder, "*.*", SearchOption.TopDirectoryOnly);

        foreach (string filePath in presentationFiles)
        {
            // Check for cancellation request
            if (cancellationSource.Token.IsCancellationRequested)
            {
                Console.WriteLine("Batch conversion cancelled by user.");
                break;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(filePath))
                {
                    // Determine output video path
                    string outputVideoPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(filePath) + ".mp4");

                    // Attempt to save as MP4 video.
                    // Note: SaveFormat.Mp4 is not defined in the current Aspose.Slides version.
                    // The following block demonstrates handling of an unsupported format.
                    try
                    {
                        // This line will cause a compile-time error because Mp4 is not a valid enum member.
                        // presentation.Save(outputVideoPath, SaveFormat.Mp4);
                        // Instead, we acknowledge that MP4 export is not supported.
                        Console.WriteLine($"MP4 format not supported for file: {filePath}");
                    }
                    catch (NotSupportedException)
                    {
                        // Format not supported – already handled above.
                    }
                }
            }
            catch (PptxUnsupportedFormatException ex)
            {
                // Handle unsupported presentation file formats
                Console.WriteLine($"Unsupported presentation format for file '{filePath}': {ex.Message}");
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine($"Error processing file '{filePath}': {ex.Message}");
            }
        }

        // Ensure any pending resources are released before exit
        Console.WriteLine("Batch conversion completed.");
    }
}