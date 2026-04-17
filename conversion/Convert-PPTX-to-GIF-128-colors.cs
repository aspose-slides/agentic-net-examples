using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.gif");

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Configure GIF export options
                // Note: GifOptions does not expose a direct property to limit the color palette to 128 colors.
                // The encoder will automatically select an appropriate palette.
                GifOptions gifOptions = new GifOptions();
                gifOptions.DefaultDelay = 1000; // optional: set default frame delay (ms)

                // Save the presentation as an animated GIF
                pres.Save(outputPath, SaveFormat.Gif, gifOptions);
            }
        }
        catch (NotSupportedException)
        {
            // Handle unsupported format exception
            Console.WriteLine("The requested format is not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}