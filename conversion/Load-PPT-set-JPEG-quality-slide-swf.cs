using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath1 = "output_quality80.swf";
        string outputPath2 = "output_quality50.swf";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Presentation pres = new Presentation(inputPath))
            {
                // Save with JPEG quality 80
                SwfOptions options1 = new SwfOptions();
                options1.JpegQuality = 80;
                pres.Save(outputPath1, SaveFormat.Swf, options1);

                // Save with JPEG quality 50
                SwfOptions options2 = new SwfOptions();
                options2.JpegQuality = 50;
                pres.Save(outputPath2, SaveFormat.Swf, options2);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported for saving as SWF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}