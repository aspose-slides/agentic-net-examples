using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfConversionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "output.swf");

            // Check if the input file exists
            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine("Input file not found: " + inputFilePath);
                return;
            }

            // Load the presentation
            Presentation presentation = null;
            try
            {
                presentation = new Presentation(inputFilePath);
            }
            catch (Exception loadEx)
            {
                Console.WriteLine("Failed to load presentation: " + loadEx.Message);
                return;
            }

            // Configure SWF options with viewer UI
            SwfOptions swfOptions = new SwfOptions();
            swfOptions.ViewerIncluded = true;          // Include integrated viewer
            swfOptions.ShowFullScreen = true;          // Show fullscreen button
            swfOptions.ShowLeftPane = true;            // Show left navigation pane
            swfOptions.ShowBottomPane = true;          // Show bottom pane
            swfOptions.ShowPageStepper = true;         // Show page stepper
            swfOptions.ShowSearch = true;              // Show search section

            // Save the presentation as SWF
            try
            {
                presentation.Save(outputFilePath, SaveFormat.Swf, swfOptions);
                Console.WriteLine("SWF file saved successfully: " + outputFilePath);
            }
            catch (Exception saveEx)
            {
                // Handle cases where the format is not supported
                Console.WriteLine("Error saving SWF file (format may not be supported): " + saveEx.Message);
            }

            // Dispose the presentation before exiting
            presentation.Dispose();
        }
    }
}