using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Configure SWF options to include the viewer toolbar
                SwfOptions swfOptions = new SwfOptions();
                swfOptions.ViewerIncluded = true;

                // Save as SWF preserving original slide layout
                string outputPath = Path.Combine(Environment.CurrentDirectory, "output.swf");
                pres.Save(outputPath, SaveFormat.Swf, swfOptions);
                Console.WriteLine("Presentation saved to SWF with viewer included: " + outputPath);
            }
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}