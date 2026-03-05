using System;
using System.IO;
using System.Drawing.Imaging;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input PPTX file path
        string inputPath = "input.pptx";
        // Output directory for JPG images
        string outputDir = "output";
        Directory.CreateDirectory(outputDir);

        // Load the presentation (creation rule)
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Iterate through each slide and save as JPG
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[i];
            // Get the slide image (using GetImage instead of non‑existent GetThumbnail)
            Aspose.Slides.IImage slideImage = slide.GetImage();
            string outputPath = Path.Combine(outputDir, $"slide_{i + 1}.jpg");
            slideImage.Save(outputPath, ImageFormat.Jpeg);
        }

        // Save the presentation before exiting (save rule)
        presentation.Save("saved_output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}