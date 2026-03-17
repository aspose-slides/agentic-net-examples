using System;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the default first slide
            Aspose.Slides.ISlide slide1 = pres.Slides[0];

            // Add two more empty slides using the first layout slide
            Aspose.Slides.ISlide slide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
            Aspose.Slides.ISlide slide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

            // Create sections and associate them with the newly added slides
            Aspose.Slides.ISection section1 = pres.Sections.AddSection("Section 1", slide2);
            Aspose.Slides.ISection section2 = pres.Sections.AddSection("Section 2", slide3);

            // Add a Summary Zoom frame to the first slide
            Aspose.Slides.ISummaryZoomFrame summaryZoom = pres.Slides[0].Shapes.AddSummaryZoomFrame(150f, 20f, 500f, 250f);

            // Add the created sections to the Summary Zoom frame
            summaryZoom.SummaryZoomCollection.AddSummaryZoomSection(section1);
            summaryZoom.SummaryZoomCollection.AddSummaryZoomSection(section2);

            // Save the presentation
            pres.Save("SummaryZoom_out.pptx", SaveFormat.Pptx);

            // Dispose the presentation
            pres.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}