using System;
using System.IO;
using Aspose.Slides;
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

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();
                tiffOptions.DpiX = 300;
                tiffOptions.DpiY = 300;
                tiffOptions.ImageSize = new System.Drawing.Size(2480, 3508); // High‑DPI custom size

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            // Handle format not supported or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}