using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesHeaderFooterExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Add three empty slides using the first layout slide of the default master
                Aspose.Slides.ILayoutSlide layoutSlide = presentation.Masters[0].LayoutSlides[0];
                for (int i = 0; i < 3; i++)
                {
                    presentation.Slides.InsertEmptySlide(presentation.Slides.Count, layoutSlide);
                }

                // Iterate through each slide to set custom header and footer text
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    // Access the slide
                    Aspose.Slides.ISlide slide = presentation.Slides[i];

                    // Manage footer on the slide
                    Aspose.Slides.IBaseSlideHeaderFooterManager slideHeaderFooter = slide.HeaderFooterManager;
                    if (!slideHeaderFooter.IsFooterVisible)
                    {
                        slideHeaderFooter.SetFooterVisibility(true);
                    }
                    string footerText = "Footer for slide " + (i + 1);
                    slideHeaderFooter.SetFooterText(footerText);

                    // Manage header on the notes slide (if it exists)
                    Aspose.Slides.INotesSlide notesSlide = slide.NotesSlideManager.NotesSlide;
                    if (notesSlide != null)
                    {
                        Aspose.Slides.INotesSlideHeaderFooterManager notesHeaderFooter = notesSlide.HeaderFooterManager;
                        if (!notesHeaderFooter.IsHeaderVisible)
                        {
                            notesHeaderFooter.SetHeaderVisibility(true);
                        }
                        string headerText = "Header for slide " + (i + 1);
                        notesHeaderFooter.SetHeaderText(headerText);
                    }
                }

                // Save the presentation
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "CustomHeaderFooter.pptx");
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}