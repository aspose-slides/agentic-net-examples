using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide (already present)
        Aspose.Slides.ISlide slide1 = presentation.Slides[0];

        // Add two more slides
        Aspose.Slides.ISlide slide2 = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
        Aspose.Slides.ISlide slide3 = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

        // Create a section starting with slide2; slide3 will belong to the same section
        Aspose.Slides.ISection section = presentation.Sections.AddSection("My Section", slide2);

        // Set AdvanceAfterTime to zero for slides in the section to require manual navigation
        presentation.Slides[1].SlideShowTransition.AdvanceAfterTime = 0;
        presentation.Slides[1].SlideShowTransition.AdvanceAfter = false;
        presentation.Slides[2].SlideShowTransition.AdvanceAfterTime = 0;
        presentation.Slides[2].SlideShowTransition.AdvanceAfter = false;

        // Save the presentation
        string outputPath = System.IO.Path.Combine(System.Environment.CurrentDirectory, "SectionManualNavigation.pptx");
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}