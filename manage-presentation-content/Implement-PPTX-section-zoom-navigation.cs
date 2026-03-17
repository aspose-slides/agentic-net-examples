using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the default first slide
            Aspose.Slides.ISlide slide1 = presentation.Slides[0];

            // Add two more empty slides based on the first layout slide
            Aspose.Slides.ISlide slide2 = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
            Aspose.Slides.ISlide slide3 = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

            // Create two sections: each starts with a specific slide
            Aspose.Slides.ISection section1 = presentation.Sections.AddSection("Section 1", slide1);
            Aspose.Slides.ISection section2 = presentation.Sections.AddSection("Section 2", slide3);

            // Add a Section Zoom frame on the first slide that links to Section 2
            Aspose.Slides.ISectionZoomFrame zoomFrame = presentation.Slides[0].Shapes.AddSectionZoomFrame(150f, 20f, 100f, 50f, section2);

            // Change the target of the zoom frame to Section 1 (optional)
            zoomFrame.TargetSection = section1;

            // Save the presentation to a PPTX file
            presentation.Save("SectionZoomDemo.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}