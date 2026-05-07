using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Determine input presentation path
        string inputPath;
        if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
        {
            inputPath = args[0];
        }
        else
        {
            inputPath = "sample.pptx";
        }

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Define output TIFF file path
        string outputTiff = Path.ChangeExtension(inputPath, ".tiff");

        try
        {
            // Load presentation
            Presentation presentation = new Presentation(inputPath);

            // Configure TIFF options with desired DPI
            TiffOptions tiffOptions = new TiffOptions();
            tiffOptions.DpiX = 200;
            tiffOptions.DpiY = 200;

            // Save presentation as TIFF using the options
            presentation.Save(outputTiff, SaveFormat.Tiff, tiffOptions);

            // Report DPI settings applied to the generated TIFF file
            using (Image tiffImage = Image.FromFile(outputTiff))
            {
                Console.WriteLine("TIFF file: " + outputTiff);
                Console.WriteLine("DPI X: " + tiffImage.HorizontalResolution);
                Console.WriteLine("DPI Y: " + tiffImage.VerticalResolution);
            }

            // Ensure presentation is saved before exit
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The specified format is not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}