using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first master slide from the presentation
        Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

        // Add a new custom layout slide to the presentation using the master slide
        Aspose.Slides.ILayoutSlide customLayout = presentation.LayoutSlides.Add(masterSlide, Aspose.Slides.SlideLayoutType.Custom, "MyCustomLayout");

        // Add a new empty slide that uses the custom layout
        Aspose.Slides.ISlide newSlide = presentation.Slides.AddEmptySlide(customLayout);

        // Save the presentation to a file
        presentation.Save("LayoutExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}