using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath;
        if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
        {
            inputPath = args[0];
        }
        else
        {
            inputPath = "sample.pptx";
        }

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            using (Presentation pres = new Presentation(inputPath))
            {
                // Set DPI options for TIFF conversion
                TiffOptions tiffOptions = new TiffOptions();
                tiffOptions.DpiX = 200;
                tiffOptions.DpiY = 200;

                string outputPath = Path.ChangeExtension(inputPath, ".tiff");
                pres.Save(outputPath, SaveFormat.Tiff, tiffOptions);

                Console.WriteLine("Converted to TIFF: " + outputPath);
                Console.WriteLine("DPI X: " + tiffOptions.DpiX);
                Console.WriteLine("DPI Y: " + tiffOptions.DpiY);
            }
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error: " + ex.Message);
            // format not supported
        }
    }
}