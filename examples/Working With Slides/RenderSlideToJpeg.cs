using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input presentation file
        string inputPath = "input.pptx";
        // Output JPEG file for the specific slide
        string outputImagePath = "slide1.jpg";
        // Output presentation file (must be saved before exit)
        string outputPresentationPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Get the specific slide (e.g., first slide)
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Render the slide to a JPEG image with full scale
        Aspose.Slides.IImage slideImage = slide.GetImage(1f, 1f);
        slideImage.Save(outputImagePath, Aspose.Slides.ImageFormat.Jpeg);

        // Save the presentation before exiting
        pres.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}