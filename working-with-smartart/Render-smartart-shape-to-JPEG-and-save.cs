using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        // Create a temporary directory for output files
        string tempDir = Path.Combine(Path.GetTempPath(), "SmartArtTemp");
        if (!Directory.Exists(tempDir))
            Directory.CreateDirectory(tempDir);

        // Define output file paths
        string outputPptx = Path.Combine(tempDir, "output.pptx");
        string outputJpeg = Path.Combine(tempDir, "smartart.jpg");

        // Create a new presentation
        Presentation pres = new Presentation();

        // Add a SmartArt shape to the first slide
        ISlide slide = pres.Slides[0];
        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

        // Render the SmartArt shape to a high‑resolution JPEG image
        Aspose.Slides.IImage smartArtImage = smartArt.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, 3f, 3f);
        smartArtImage.Save(outputJpeg, Aspose.Slides.ImageFormat.Jpeg);

        // Save the presentation before exiting
        pres.Save(outputPptx, SaveFormat.Pptx);

        // Clean up
        pres.Dispose();
    }
}