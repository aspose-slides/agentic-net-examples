using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Configure header and footer for all slides
            Aspose.Slides.IPresentationHeaderFooterManager headerFooterMgr = presentation.HeaderFooterManager;
            headerFooterMgr.SetAllHeadersVisibility(true);
            headerFooterMgr.SetAllFootersVisibility(true);
            headerFooterMgr.SetAllHeadersText("Custom Header");
            headerFooterMgr.SetAllFootersText("Custom Footer");
            headerFooterMgr.SetAllSlideNumbersVisibility(true);

            // Add an additional slide using the first layout of the first master
            Aspose.Slides.IMasterSlide master = presentation.Masters[0];
            Aspose.Slides.ILayoutSlide layout = master.LayoutSlides[0];
            Aspose.Slides.ISlide newSlide = presentation.Slides.AddEmptySlide(layout);

            // Save the presentation
            presentation.Save("CustomHeaderFooter.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}