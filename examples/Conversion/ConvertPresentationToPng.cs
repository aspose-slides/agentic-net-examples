using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Input PowerPoint file
        System.String inputPath = "sample.pptx";

        // Output folder for PNG images
        System.String outputFolder = "output";
        System.IO.Directory.CreateDirectory(outputFolder);

        // Scaling factors for custom dimensions
        System.Int32 scaleX = 2;
        System.Int32 scaleY = scaleX;

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Convert each slide to a PNG image with the specified scale
        foreach (Aspose.Slides.ISlide slide in presentation.Slides)
        {
            using (Aspose.Slides.IImage image = slide.GetImage(scaleX, scaleY))
            {
                System.String imageFileName = System.String.Format(
                    System.IO.Path.Combine(outputFolder, "Slide_{0}.png"),
                    slide.SlideNumber);
                image.Save(imageFileName, Aspose.Slides.ImageFormat.Png);
            }
        }

        // Save the presentation before exiting (no modifications made)
        presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}