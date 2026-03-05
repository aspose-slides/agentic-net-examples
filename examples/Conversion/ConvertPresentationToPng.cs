using System;
using System.IO;
using System.Drawing.Imaging;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input presentation (PPT or PPTX)
        string inputPath = "input.pptx";

        // Folder to store PNG images
        string outputFolder = "output";
        Directory.CreateDirectory(outputFolder);

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Iterate through all slides and save each as PNG
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[i];
            Aspose.Slides.IImage image = slide.GetImage();
            string outputPath = Path.Combine(outputFolder, $"slide_{i + 1}.png");
            image.Save(outputPath, ImageFormat.Png);
            image.Dispose();
        }

        // Save the (unchanged) presentation before exiting as required
        presentation.Save("saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}