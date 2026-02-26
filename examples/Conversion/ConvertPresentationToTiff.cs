using System;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPT or PPTX file
        string inputPath = "input.pptx";
        // Path where the TIFF file will be saved
        string outputPath = "output.tiff";

        // Load the presentation from the specified file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Create TIFF save options (optional configuration)
            Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();
            // Example: set the resolution of the output image
            tiffOptions.DpiX = 200;
            tiffOptions.DpiY = 200;

            // Save the presentation as a multi‑page TIFF file
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);
        }
    }
}