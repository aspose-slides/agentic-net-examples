using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.swf";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Create SWF export options
                SwfOptions swfOptions = new SwfOptions();

                // Determine deployment platform (example: environment variable)
                string platform = Environment.GetEnvironmentVariable("DEPLOY_PLATFORM");
                if (string.Equals(platform, "Web", StringComparison.OrdinalIgnoreCase))
                {
                    // For web deployment, exclude the integrated viewer
                    swfOptions.ViewerIncluded = false;
                }
                else
                {
                    // For other platforms, include the viewer
                    swfOptions.ViewerIncluded = true;
                }

                // Save the presentation as SWF with the configured options
                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
            }
        }
        // Handle unsupported file format exceptions
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // Format not supported
            Console.WriteLine("The presentation format is not supported.");
        }
        // General exception handling
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}