using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source presentation
            string inputPath = "input.pptx";
            // Path for the output TIFF file
            string outputPath = "output.tiff";

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Configure TIFF export options with a custom pixel format
            TiffOptions options = new TiffOptions();
            options.PixelFormat = ImagePixelFormat.Format8bppIndexed;

            // Save the presentation as a TIFF image using the specified options
            presentation.Save(outputPath, SaveFormat.Tiff, options);
        }
        catch (Exception ex)
        {
            // Output any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}