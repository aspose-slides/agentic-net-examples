using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first master slide
        Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

        // Add a new custom layout slide to the master
        Aspose.Slides.ILayoutSlide newLayout = masterSlide.LayoutSlides.Add(Aspose.Slides.SlideLayoutType.Custom, "MyCustomLayout");

        // Save the presentation
        presentation.Save("AddLayout.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}