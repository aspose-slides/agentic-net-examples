using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Set custom slide size with a 16:9 aspect ratio (e.g., 960x540 points)
        presentation.SlideSize.SetSize(960f, 540f, Aspose.Slides.SlideSizeScaleType.DoNotScale);

        // Save the presentation
        string outputPath = "Custom16by9.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}