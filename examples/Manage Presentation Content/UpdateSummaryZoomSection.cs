using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add two sections with slides
        Aspose.Slides.ISection section1 = pres.Sections.AddSection("Section 1", pres.Slides[0]);
        Aspose.Slides.ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
        Aspose.Slides.ISection section2 = pres.Sections.AddSection("Section 2", slide2);

        // Add a Summary Zoom frame to the first slide
        Aspose.Slides.IShapeCollection shapes = pres.Slides[0].Shapes;
        Aspose.Slides.ISummaryZoomFrame zoomFrame = shapes.AddSummaryZoomFrame(100f, 100f, 300f, 200f);

        // Get the collection of summary zoom sections
        Aspose.Slides.ISummaryZoomSectionCollection collection = zoomFrame.SummaryZoomCollection;

        // Add a summary zoom section for the second section
        Aspose.Slides.ISummaryZoomSection addedSection = collection.AddSummaryZoomSection(section2);

        // Remove the previously added summary zoom section
        collection.RemoveSummaryZoomSection(section2);

        // Save the presentation
        pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}