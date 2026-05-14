using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = System.IO.Path.Combine(System.Environment.CurrentDirectory, "SectionManualNavigation.pptx");
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add additional slides
            Aspose.Slides.ISlide slide1 = pres.Slides[0];
            Aspose.Slides.ISlide slide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
            Aspose.Slides.ISlide slide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

            // Create a section starting with slide2
            Aspose.Slides.ISection section = pres.Sections.AddSection("Manual Navigation Section", slide2);

            // Set transition for slides in the section to require manual navigation (AdvanceAfterTime = 0)
            pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
            pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 0;
            pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
            pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 0;

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.NotSupportedException)
        {
            // Format not supported
        }
        catch (System.Exception)
        {
            // Handle other exceptions (e.g., file I/O, network)
        }
    }
}