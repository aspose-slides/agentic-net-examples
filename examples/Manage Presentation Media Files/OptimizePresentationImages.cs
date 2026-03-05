using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "input.pptx");
        string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output.pptx");

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Get the first shape as a picture frame
        Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes[0] as Aspose.Slides.IPictureFrame;

        // If a picture frame exists, compress its image
        if (pictureFrame != null)
        {
            bool compressionResult = pictureFrame.PictureFormat.CompressImage(true, Aspose.Slides.Export.PicturesCompression.Dpi150);
        }

        // Save the optimized presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}