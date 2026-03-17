using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace UpdateHeaderFooter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define paths
                string dataDir = "Data";
                string inputPath = Path.Combine(dataDir, "input.pptx");
                string outputPath = Path.Combine(dataDir, "output.pptx");

                // Load presentation
                Presentation presentation = new Presentation(inputPath);

                // Master notes slide header/footer settings
                IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
                if (masterNotesSlide != null)
                {
                    IMasterNotesSlideHeaderFooterManager masterHeaderFooter = masterNotesSlide.HeaderFooterManager;
                    masterHeaderFooter.SetHeaderAndChildHeadersVisibility(true);
                    masterHeaderFooter.SetFooterAndChildFootersVisibility(true);
                    masterHeaderFooter.SetSlideNumberAndChildSlideNumbersVisibility(true);
                    masterHeaderFooter.SetDateTimeAndChildDateTimesVisibility(true);
                    masterHeaderFooter.SetHeaderAndChildHeadersText("Header");
                    masterHeaderFooter.SetFooterAndChildFootersText("Footer");
                    masterHeaderFooter.SetDateTimeAndChildDateTimesText("01/01/2026");
                }

                // Notes slide header/footer settings for the first slide (index 0)
                INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
                if (notesSlide != null)
                {
                    INotesSlideHeaderFooterManager notesHeaderFooter = notesSlide.HeaderFooterManager;
                    if (!notesHeaderFooter.IsHeaderVisible)
                    {
                        notesHeaderFooter.SetHeaderVisibility(true);
                    }
                    if (!notesHeaderFooter.IsFooterVisible)
                    {
                        notesHeaderFooter.SetFooterVisibility(true);
                    }
                    if (!notesHeaderFooter.IsSlideNumberVisible)
                    {
                        notesHeaderFooter.SetSlideNumberVisibility(true);
                    }
                    if (!notesHeaderFooter.IsDateTimeVisible)
                    {
                        notesHeaderFooter.SetDateTimeVisibility(true);
                    }
                    notesHeaderFooter.SetHeaderText("New Header");
                    notesHeaderFooter.SetFooterText("New Footer");
                    notesHeaderFooter.SetDateTimeText("02/02/2026");
                }

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}