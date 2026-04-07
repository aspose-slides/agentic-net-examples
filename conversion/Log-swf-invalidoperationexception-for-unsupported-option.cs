using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        var outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.swf");

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                var swfOptions = new Aspose.Slides.Export.SwfOptions();

                // Attempt to set an unsupported SlidesLayoutOptions to trigger InvalidOperationException
                try
                {
                    // HandoutLayoutingOptions is not supported for SlidesLayoutOptions
                    swfOptions.SlidesLayoutOptions = new Aspose.Slides.Export.HandoutLayoutingOptions();
                }
                catch (InvalidOperationException ex)
                {
                    // Log the exception
                    Console.WriteLine("SwfOptions InvalidOperationException: " + ex.Message);
                }

                // Save presentation as SWF
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Aspose.Slides.PptUnsupportedFormatException)
        {
            // format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}