using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfConversionWithProgress
{
    // Implements progress callback to report conversion progress
    public class ProgressReporter : Aspose.Slides.IProgressCallback
    {
        public void Reporting(double progressValue)
        {
            Console.WriteLine("Conversion progress: {0}%", progressValue);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "LargePresentation.pptx";
            string outputPath = "LargePresentation.swf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation and handle unsupported format
            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The input file format is not supported for conversion.");
                return;
            }
            catch (Exception ex)
            {
                // Handle other loading exceptions
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // Set up SWF conversion options with progress reporting
            Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
            swfOptions.ProgressCallback = new ProgressReporter();

            // Perform the conversion and save the SWF file
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during conversion: " + ex.Message);
            }
            finally
            {
                // Ensure the presentation is saved before exiting and resources are released
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }

            Console.WriteLine("Conversion completed.");
        }
    }
}