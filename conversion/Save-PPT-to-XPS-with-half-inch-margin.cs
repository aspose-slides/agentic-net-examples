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
            Presentation presentation = new Presentation(inputPath);

            // Create XPS options
            XpsOptions options = new XpsOptions();

            // Aspose.Slides does not provide a direct margin property for XPS export.
            // As a workaround, you can enable a frame around each slide to visualize margins.
            options.DrawSlidesFrame = true;

            // Save the presentation as XPS with the specified options
            presentation.Save(outputPath, SaveFormat.Xps, options);

            // Dispose the presentation object
            presentation.Dispose();

            Console.WriteLine("Presentation successfully saved as XPS: " + outputPath);
        }
        catch (NotSupportedException)
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