using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Ensure there is at least one section with a slide
            if (pres.Sections.Count == 0)
            {
                // Add a slide using the layout of the first (default) slide
                Aspose.Slides.ISlide newSlide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
                // Add a section that contains the new slide
                pres.Sections.AddSection("Section 1", newSlide);
            }

            // Insert a Summary Zoom frame on the first slide
            Aspose.Slides.IShapeCollection shapeCollection = pres.Slides[0].Shapes;
            Aspose.Slides.ISummaryZoomFrame zoomFrame = shapeCollection.AddSummaryZoomFrame(150f, 20f, 500f, 250f);

            // Add a Summary Zoom Section for the first section
            Aspose.Slides.ISection targetSection = pres.Sections[0];
            Aspose.Slides.ISummaryZoomSection addedSection = zoomFrame.SummaryZoomCollection.AddSummaryZoomSection(targetSection);

            // Remove the previously added Summary Zoom Section
            zoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(targetSection);

            // Save the modified presentation
            pres.Save("Output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}