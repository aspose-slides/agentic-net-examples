using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.xps";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Create XPS save options
                XpsOptions options = new XpsOptions();

                // The XpsOptions class does not expose a 'Compress' property in the current API.
                // If compression control were available, it would be set here, e.g.:
                // options.Compress = false;

                // Save the presentation as an uncompressed XPS file for debugging
                presentation.Save(outputPath, SaveFormat.Xps, options);
            }
        }
        catch (PptxUnsupportedFormatException)
        {
            // Handle unsupported file format
            Console.WriteLine("The file format is not supported for XPS conversion.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}