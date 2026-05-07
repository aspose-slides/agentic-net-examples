using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfExportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputFileName = "input.pptx";
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);
            string outputFileName = "output.swf";
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), outputFileName);

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Configure SWF options with viewer UI enabled
                SwfOptions swfOptions = new SwfOptions();
                swfOptions.ViewerIncluded = true;          // Include integrated viewer
                swfOptions.ShowFullScreen = true;         // Show fullscreen button
                swfOptions.ShowPageStepper = true;        // Show page stepper (navigation)
                swfOptions.ShowSearch = true;             // Show search pane
                swfOptions.ShowLeftPane = true;           // Show left navigation pane
                swfOptions.ShowBottomPane = true;         // Show bottom pane

                // Save the presentation as SWF
                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

                // Dispose the presentation before exiting
                presentation.Dispose();

                Console.WriteLine("SWF file created successfully at: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Handle unsupported format exception
                Console.WriteLine("The file format is not supported for SWF conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}