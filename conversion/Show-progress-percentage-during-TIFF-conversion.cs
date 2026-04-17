using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesTiffConversion
{
    // Implements progress callback to display conversion progress
    public class ConsoleProgressCallback : IProgressCallback
    {
        public void Reporting(double progressValue)
        {
            // Ensure progress is displayed as an integer percentage
            int percent = (int)progressValue;
            Console.Write("\rConverting to TIFF: {0}%   ", percent);
            if (percent >= 100)
            {
                Console.WriteLine();
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.tiff";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Configure TIFF options with progress callback
                    TiffOptions tiffOptions = new TiffOptions();
                    tiffOptions.ProgressCallback = new ConsoleProgressCallback();

                    // Optional: set DPI or other options here
                    // tiffOptions.DpiX = 200;
                    // tiffOptions.DpiY = 200;

                    // Save the presentation as a multi‑page TIFF
                    presentation.Save(outputPath, SaveFormat.Tiff, tiffOptions);
                }

                Console.WriteLine("TIFF conversion completed successfully.");
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("Error: The specified format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., external URL or web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}