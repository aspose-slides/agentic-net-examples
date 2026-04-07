using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.swf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Create SWF options
            Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();

            // Adjust compression based on bandwidth constraints
            bool lowBandwidth = true; // Placeholder condition for bandwidth check
            if (lowBandwidth)
            {
                swfOptions.Compressed = false;
            }
            else
            {
                swfOptions.Compressed = true;
            }

            // Save the presentation as SWF with the specified options
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}