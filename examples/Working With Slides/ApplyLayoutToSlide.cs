using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the presentation from a PPTX file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Retrieve the first layout slide from the presentation
        Aspose.Slides.ILayoutSlide layoutSlide = presentation.LayoutSlides[0];

        // Add a new empty slide using the retrieved layout
        Aspose.Slides.ISlide newSlide = presentation.Slides.AddEmptySlide(layoutSlide);

        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}