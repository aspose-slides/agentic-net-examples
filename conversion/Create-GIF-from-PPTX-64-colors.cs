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
        string outputPath = "output.gif";

        // Check if the input PPTX file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Create GIF export options
            GifOptions options = new GifOptions();

            // Note: Limiting the color palette to 64 colors is not directly supported via GifOptions.
            // This would require additional processing not covered by Aspose.Slides.

            // Save the presentation as an animated GIF
            pres.Save(outputPath, SaveFormat.Gif, options);

            // Dispose the presentation object
            pres.Dispose();
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