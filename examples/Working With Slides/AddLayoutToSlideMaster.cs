using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first master slide
        Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

        // Add a new layout slide to the master slide
        Aspose.Slides.ILayoutSlide newLayout = masterSlide.LayoutSlides.Add(Aspose.Slides.SlideLayoutType.Title, "CustomTitleLayout");

        // Save the presentation
        presentation.Save("AddLayoutSlide.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}