using System;
using System.Drawing.Imaging;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input presentation, output PNG, and saved presentation
        string inputPath = "input.pptx";
        string outputPngPath = "slide_0.png";
        string outputPresentationPath = "output.pptx";

        // Load the presentation from file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Access the first slide in the presentation
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Generate a thumbnail image of the slide (default size)
        Aspose.Slides.IImage slideImage = slide.GetImage();

        // Save the slide image as a PNG file
        slideImage.Save(outputPngPath, ImageFormat.Png);

        // Save the (potentially modified) presentation before exiting
        presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        slideImage.Dispose();
        presentation.Dispose();
    }
}