using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (Presentation presentation = new Presentation())
            {
                // Iterate through all slides in the presentation
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    ISlide slide = presentation.Slides[i];
                    ISlideHeaderFooterManager headerFooter = slide.HeaderFooterManager;

                    // Ensure footer placeholder is visible and set custom text
                    if (!headerFooter.IsFooterVisible)
                    {
                        headerFooter.SetFooterVisibility(true);
                    }
                    headerFooter.SetFooterText("Custom Footer Text");

                    // Ensure date-time placeholder is visible and set custom text
                    if (!headerFooter.IsDateTimeVisible)
                    {
                        headerFooter.SetDateTimeVisibility(true);
                    }
                    headerFooter.SetDateTimeText("Custom Date");

                    // Ensure slide number placeholder is visible
                    if (!headerFooter.IsSlideNumberVisible)
                    {
                        headerFooter.SetSlideNumberVisibility(true);
                    }
                }

                // Save the presentation to a file
                presentation.Save("CustomHeaderFooter.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}