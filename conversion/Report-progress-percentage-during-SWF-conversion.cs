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

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Configure SWF options with progress callback
                SwfOptions swfOptions = new SwfOptions();
                swfOptions.ProgressCallback = new ProgressReporter();

                // Convert to SWF with progress reporting
                pres.Save(outputPath, SaveFormat.Swf, swfOptions);

                // Save presentation before exit (intermediate PPTX)
                string intermediatePath = "intermediate.pptx";
                pres.Save(intermediatePath, SaveFormat.Pptx);
            }
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

    // Progress callback implementation
    private class ProgressReporter : IProgressCallback
    {
        public void Reporting(double progressValue)
        {
            int progress = Convert.ToInt32(progressValue);
            Console.WriteLine("Progress: " + progress + "%");
        }
    }
}