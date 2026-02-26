using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation instance
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Add a Summary Zoom frame to the first slide
            Aspose.Slides.ISummaryZoomFrame zoomFrame = presentation.Slides[0].Shapes.AddSummaryZoomFrame(150f, 20f, 500f, 250f);

            // Set alternative text for the zoom frame (optional)
            zoomFrame.AlternativeText = "Summary Zoom";

            // Save the presentation to a PPTX file
            presentation.Save("SummaryZoomPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}