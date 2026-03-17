using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (var presentation = new Presentation())
            {
                // Set custom header and footer text for all slides
                presentation.HeaderFooterManager.SetAllHeadersText("Custom Header");
                presentation.HeaderFooterManager.SetAllFootersText("Custom Footer");

                // Ensure header and footer placeholders are visible
                presentation.HeaderFooterManager.SetAllHeadersVisibility(true);
                presentation.HeaderFooterManager.SetAllFootersVisibility(true);

                // Optionally show slide numbers on all slides
                presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

                // Save the presentation before exiting
                presentation.Save("OutputPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}