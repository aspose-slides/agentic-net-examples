using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPathDefault = "output_default.tiff";
        string outputPathIndexed = "output_indexed.tiff";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Save with default TIFF options
                presentation.Save(outputPathDefault, Aspose.Slides.Export.SaveFormat.Tiff);

                // Configure TIFF options with 8bpp indexed pixel format
                Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();
                tiffOptions.PixelFormat = Aspose.Slides.Export.ImagePixelFormat.Format8bppIndexed;

                // Save with custom pixel format
                presentation.Save(outputPathIndexed, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);
            }

            // Retrieve file sizes
            long sizeDefault = new FileInfo(outputPathDefault).Length;
            long sizeIndexed = new FileInfo(outputPathIndexed).Length;

            // Compute size reduction
            long reduction = sizeDefault - sizeIndexed;
            double reductionPercent = sizeDefault > 0 ? (double)reduction / sizeDefault * 100 : 0;

            Console.WriteLine("Default TIFF size: " + sizeDefault + " bytes");
            Console.WriteLine("Indexed TIFF size: " + sizeIndexed + " bytes");
            Console.WriteLine("Size reduction: " + reduction + " bytes (" + reductionPercent.ToString("F2") + "%)");
        }
        catch (NotSupportedException ex)
        {
            // Format not supported
            Console.WriteLine("The requested format is not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}