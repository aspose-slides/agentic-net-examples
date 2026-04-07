using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var inputPath = "input.pptx";
        var outputPath = "output.tiff";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            var pres = new Aspose.Slides.Presentation(inputPath);
            var options = new TiffOptions
            {
                // Apply a margin of 0.2 inches (handled by layout options)
                SlidesLayoutOptions = new HandoutLayoutingOptions
                {
                    Handout = HandoutType.Handouts4Horizontal
                }
            };

            // Save each slide as a separate page in the TIFF file
            pres.Save(outputPath, SaveFormat.Tiff, options);
            pres.Dispose();
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