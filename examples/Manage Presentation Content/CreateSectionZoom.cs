using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first (default) slide
        Aspose.Slides.ISlide firstSlide = presentation.Slides[0];

        // Add a slide that will belong to the first section
        Aspose.Slides.ISlide slideForSection1 = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
        // Create the first section starting from the newly added slide
        Aspose.Slides.ISection section1 = presentation.Sections.AddSection("Section 1", slideForSection1);

        // Add another slide for the second section
        Aspose.Slides.ISlide slideForSection2 = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
        // Create the second section
        Aspose.Slides.ISection section2 = presentation.Sections.AddSection("Section 2", slideForSection2);

        // Add a Section Zoom frame to the first slide, linking it to the second section
        Aspose.Slides.ISectionZoomFrame zoomFrame = firstSlide.Shapes.AddSectionZoomFrame(150, 20, 50, 50, section2);

        // Save the presentation
        presentation.Save("SectionZoom_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}