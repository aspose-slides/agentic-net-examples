using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation (contains one empty slide by default)
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Obtain a layout slide from the existing first slide
        Aspose.Slides.ILayoutSlide layout = presentation.Slides[0].LayoutSlide;

        // Add a new empty slide using the obtained layout
        Aspose.Slides.ISlide newSlide = presentation.Slides.AddEmptySlide(layout);

        // Save the presentation to a file
        presentation.Save("AddedSlide.pptx", SaveFormat.Pptx);
    }
}