using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();

            var headerFooterManager = presentation.HeaderFooterManager;

            // Make footer visible and set its text
            headerFooterManager.SetAllFootersVisibility(true);
            headerFooterManager.SetAllFootersText("Company Confidential");

            // Make date-time visible and set its text
            headerFooterManager.SetAllDateTimesVisibility(true);
            headerFooterManager.SetAllDateTimesText(DateTime.Now.ToString("yyyy-MM-dd"));

            // Make slide numbers visible
            headerFooterManager.SetAllSlideNumbersVisibility(true);

            // Save the presentation
            presentation.Save("OutputPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}