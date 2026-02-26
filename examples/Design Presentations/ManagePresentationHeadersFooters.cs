using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the presentation-level header/footer manager
        Aspose.Slides.IPresentationHeaderFooterManager presHeaderFooter = presentation.HeaderFooterManager;

        // Make all footers visible and set their text
        presHeaderFooter.SetAllFootersVisibility(true);
        presHeaderFooter.SetAllFootersText("Company Confidential");

        // Make all date-time placeholders visible and set their text
        presHeaderFooter.SetAllDateTimesVisibility(true);
        presHeaderFooter.SetAllDateTimesText("01/01/2026");

        // Make all slide numbers visible
        presHeaderFooter.SetAllSlideNumbersVisibility(true);

        // Modify the first slide individually
        Aspose.Slides.ISlide firstSlide = presentation.Slides[0];
        Aspose.Slides.ISlideHeaderFooterManager slideHeaderFooter = firstSlide.HeaderFooterManager;

        slideHeaderFooter.SetFooterVisibility(true);
        slideHeaderFooter.SetFooterText("First Slide Footer");
        slideHeaderFooter.SetSlideNumberVisibility(true);
        slideHeaderFooter.SetDateTimeVisibility(true);
        slideHeaderFooter.SetDateTimeText("Jan 2026");

        // Save the presentation
        presentation.Save("ManagedHeadersFooters.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}