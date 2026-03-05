using System;

class Program
{
    static void Main(string[] args)
    {
        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Retrieve a layout slide from the presentation (e.g., the first layout)
        Aspose.Slides.ILayoutSlide layoutSlide = presentation.LayoutSlides[0];

        // Add a new empty slide using the selected layout
        Aspose.Slides.ISlide newSlide = presentation.Slides.AddEmptySlide(layoutSlide);

        // Apply the layout to an existing slide (e.g., the first slide)
        presentation.Slides[0].LayoutSlide = layoutSlide;

        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}