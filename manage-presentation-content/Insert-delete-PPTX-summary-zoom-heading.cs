using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (var presentation = new Aspose.Slides.Presentation())
            {
                // Ensure at least two sections in the presentation
                var firstSlide = presentation.Slides[0];
                presentation.Sections.AddSection("Section 1", firstSlide);

                var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);
                presentation.Sections.AddSection("Section 2", secondSlide);

                // Insert a Summary Zoom frame on the first slide
                var zoomFrame = presentation.Slides[0].Shapes.AddSummaryZoomFrame(150f, 20f, 500f, 250f);

                // Add a Summary Zoom Section for the second section
                var collection = zoomFrame.SummaryZoomCollection;
                var addedSection = collection.AddSummaryZoomSection(presentation.Sections[1]);

                // Remove the previously added Summary Zoom Section
                collection.RemoveSummaryZoomSection(presentation.Sections[1]);

                // Save the modified presentation
                presentation.Save("SummaryZoomDemo_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}