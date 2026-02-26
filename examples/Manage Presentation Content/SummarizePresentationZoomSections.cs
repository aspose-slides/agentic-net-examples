using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Add a second empty slide based on the layout of the first slide
            Aspose.Slides.ISlide secondSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

            // Create two sections and assign slides to them
            presentation.Sections.AddSection("Section 1", presentation.Slides[0]);
            presentation.Sections.AddSection("Section 2", secondSlide);

            // Add a Summary Zoom frame to the first slide
            Aspose.Slides.ISummaryZoomFrame zoomFrame = presentation.Slides[0].Shapes.AddSummaryZoomFrame(150, 20, 500, 250);

            // Access the collection of Summary Zoom sections within the frame
            Aspose.Slides.ISummaryZoomSectionCollection zoomCollection = zoomFrame.SummaryZoomCollection;

            // Add a Summary Zoom section that links to the second section
            Aspose.Slides.ISection targetSection = presentation.Sections[1];
            Aspose.Slides.ISummaryZoomSection summaryZoomSection = zoomCollection.AddSummaryZoomSection(targetSection);

            // Set a custom title for the newly added Summary Zoom section
            summaryZoomSection.Title = "Navigate to Section 2";

            // Retrieve the same Summary Zoom section using GetSummarySection
            Aspose.Slides.ISummaryZoomSection retrievedSection = zoomCollection.GetSummarySection(targetSection);

            // Remove the Summary Zoom section from the collection
            zoomCollection.RemoveSummaryZoomSection(targetSection);

            // Save the presentation to a file
            presentation.Save("SummaryZoomExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}