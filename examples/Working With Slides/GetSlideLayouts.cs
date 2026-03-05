using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing PPTX file
        Presentation presentation = new Presentation("input.pptx");

        // Get the first master slide in the presentation
        IMasterSlide masterSlide = presentation.Masters[0];

        // Add a new custom layout slide to the presentation
        ILayoutSlide customLayout = presentation.LayoutSlides.Add(masterSlide, SlideLayoutType.Custom, "MyCustomLayout");

        // Insert a new empty slide that uses the newly added layout
        ISlide newSlide = presentation.Slides.InsertEmptySlide(0, customLayout);

        // Save the modified presentation
        presentation.Save("output.pptx", SaveFormat.Pptx);
    }
}