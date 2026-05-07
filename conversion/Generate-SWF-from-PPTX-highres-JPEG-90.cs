using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.swf";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Configure SWF options with high JPEG quality
            Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
            swfOptions.JpegQuality = 90;

            // Save the presentation as SWF with the specified options
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

            // Dispose the presentation object
            presentation.Dispose();

            Console.WriteLine("Conversion to SWF completed successfully.");
        }
        catch (NotSupportedException ex)
        {
            // Handle unsupported format exception
            Console.WriteLine("The file format is not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // Handle other exceptions
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}