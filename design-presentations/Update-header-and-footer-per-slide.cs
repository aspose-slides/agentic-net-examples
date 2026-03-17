using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Define data directory and file paths
            string dataDir = "Data";
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Configure master notes slide header, footer, date-time and slide number
            IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
            if (masterNotesSlide != null)
            {
                IMasterNotesSlideHeaderFooterManager masterHeaderFooter = masterNotesSlide.HeaderFooterManager;
                masterHeaderFooter.SetHeaderAndChildHeadersVisibility(true);
                masterHeaderFooter.SetFooterAndChildFootersVisibility(true);
                masterHeaderFooter.SetSlideNumberAndChildSlideNumbersVisibility(true);
                masterHeaderFooter.SetDateTimeAndChildDateTimesVisibility(true);
                masterHeaderFooter.SetHeaderAndChildHeadersText("Master Header");
                masterHeaderFooter.SetFooterAndChildFootersText("Master Footer");
                masterHeaderFooter.SetDateTimeAndChildDateTimesText("01/01/2026");
            }

            // Iterate through each slide to set individual header/footer/date-time
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                ISlide slide = presentation.Slides[i];
                IBaseSlideHeaderFooterManager slideHeaderFooter = slide.HeaderFooterManager;

                // Show footer on even slides, hide on odd slides
                if (i % 2 == 0)
                {
                    if (!slideHeaderFooter.IsFooterVisible)
                        slideHeaderFooter.SetFooterVisibility(true);
                    slideHeaderFooter.SetFooterText($"Footer for slide {i + 1}");
                }
                else
                {
                    if (slideHeaderFooter.IsFooterVisible)
                        slideHeaderFooter.SetFooterVisibility(false);
                }

                // Ensure date-time placeholder is visible and set its text
                if (!slideHeaderFooter.IsDateTimeVisible)
                    slideHeaderFooter.SetDateTimeVisibility(true);
                slideHeaderFooter.SetDateTimeText("DateTime Text");

                // Modify notes slide header/footer for the current slide
                INotesSlide notesSlide = presentation.Slides[i].NotesSlideManager.NotesSlide;
                if (notesSlide != null)
                {
                    INotesSlideHeaderFooterManager notesHeaderFooter = notesSlide.HeaderFooterManager;
                    if (!notesHeaderFooter.IsHeaderVisible)
                        notesHeaderFooter.SetHeaderVisibility(true);
                    if (!notesHeaderFooter.IsFooterVisible)
                        notesHeaderFooter.SetFooterVisibility(true);
                    notesHeaderFooter.SetHeaderText($"Notes Header {i + 1}");
                    notesHeaderFooter.SetFooterText($"Notes Footer {i + 1}");
                }
            }

            // Save the updated presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}