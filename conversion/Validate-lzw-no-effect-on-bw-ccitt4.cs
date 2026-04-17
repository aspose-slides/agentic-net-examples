using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.tiff";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("File format not supported.");
            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading presentation: " + ex.Message);
            return;
        }

        Aspose.Slides.Export.TiffOptions options = new Aspose.Slides.Export.TiffOptions();
        // Set LZW compression first (should not affect BW conversion when later using CCITT4)
        options.CompressionType = Aspose.Slides.Export.TiffCompressionTypes.LZW;
        // Set black‑and‑white conversion mode
        options.BwConversionMode = Aspose.Slides.Export.BlackWhiteConversionMode.Dithering;
        // Now set CCITT4 compression which enables BW conversion
        options.CompressionType = Aspose.Slides.Export.TiffCompressionTypes.CCITT4;

        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving TIFF: " + ex.Message);
        }

        // Save presentation before exit
        string savedPresentationPath = "saved.pptx";
        try
        {
            presentation.Save(savedPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }

        if (presentation != null)
        {
            presentation.Dispose();
        }
    }
}