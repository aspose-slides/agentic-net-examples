using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Set custom slide size (width: 800 points, height: 600 points) without scaling existing content
        presentation.SlideSize.SetSize(800f, 600f, Aspose.Slides.SlideSizeScaleType.DoNotScale);

        // Save the presentation to disk
        presentation.Save("RectangleSize.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}