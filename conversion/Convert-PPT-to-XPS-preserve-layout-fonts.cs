using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.ppt";
        string outputPath = "output.xps";

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

            // Create XPS options (default settings preserve layout and fonts)
            Aspose.Slides.Export.XpsOptions xpsOptions = new Aspose.Slides.Export.XpsOptions();

            // Save the presentation as XPS
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Xps, xpsOptions);

            // Release resources
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported for conversion.");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}