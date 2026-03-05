using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first master slide from the presentation
        Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

        // Select a predefined layout slide from the master (e.g., the first layout)
        Aspose.Slides.ILayoutSlide layoutSlide = masterSlide.LayoutSlides[0];

        // Add a new empty slide based on the selected layout
        Aspose.Slides.ISlide newSlide = presentation.Slides.AddEmptySlide(layoutSlide);

        // Save the presentation to a file
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}