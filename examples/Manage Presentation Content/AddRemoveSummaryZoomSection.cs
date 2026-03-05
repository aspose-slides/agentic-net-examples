using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a slide to the presentation
        Aspose.Slides.ISlide firstSlide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

        // Add a section that contains the first slide
        Aspose.Slides.ISection section1 = pres.Sections.AddSection("Section 1", firstSlide);

        // Add a second slide
        Aspose.Slides.ISlide secondSlide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

        // Add a second section that contains the second slide
        Aspose.Slides.ISection section2 = pres.Sections.AddSection("Section 2", secondSlide);

        // Add a Summary Zoom frame to the first slide
        Aspose.Slides.IShapeCollection shapeCollection = pres.Slides[0].Shapes;
        Aspose.Slides.ISummaryZoomFrame zoomFrame = shapeCollection.AddSummaryZoomFrame(150f, 20f, 500f, 250f);

        // Get the collection of Summary Zoom sections
        Aspose.Slides.ISummaryZoomSectionCollection zoomSectionCollection = zoomFrame.SummaryZoomCollection;

        // Add a Summary Zoom Section for the second section
        Aspose.Slides.ISummaryZoomSection addedZoomSection = zoomSectionCollection.AddSummaryZoomSection(section2);

        // Remove the previously added Summary Zoom Section
        zoomSectionCollection.RemoveSummaryZoomSection(section2);

        // Save the presentation
        pres.Save("SummaryZoomExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}