using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Add additional slides to have content for sections
        var slide1 = presentation.Slides[0];
        var slide2 = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
        var slide3 = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

        // Create sections and associate them with slides
        var section1 = presentation.Sections.AddSection("Section 1", slide2);
        var section2 = presentation.Sections.AddSection("Section 2", slide3);

        // Add a Section Zoom Frame to the first slide, linking to the second section
        var zoomFrame = slide1.Shapes.AddSectionZoomFrame(150f, 20f, 100f, 100f, section2);

        // Set optional properties (e.g., alternative text)
        zoomFrame.AlternativeText = "Zoom to Section 2";

        // Save the presentation before exiting
        presentation.Save("SectionZoomExample.pptx", SaveFormat.Pptx);
    }
}