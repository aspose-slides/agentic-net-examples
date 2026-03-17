using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HeaderFooterExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                using (var presentation = new Presentation())
                {
                    var slideCount = presentation.Slides.Count;
                    for (int i = 0; i < slideCount; i++)
                    {
                        var slide = presentation.Slides[i];
                        var headerFooterManager = slide.HeaderFooterManager;

                        // Ensure footer is visible and set its text
                        headerFooterManager.SetFooterVisibility(true);
                        headerFooterManager.SetFooterText("Sample Footer");

                        // Ensure date-time placeholder is visible and set its text
                        headerFooterManager.SetDateTimeVisibility(true);
                        headerFooterManager.SetDateTimeText("01/01/2026");

                        // Ensure slide number placeholder is visible
                        headerFooterManager.SetSlideNumberVisibility(true);
                    }

                    // Save the presentation
                    presentation.Save("HeaderFooterPresentation.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}