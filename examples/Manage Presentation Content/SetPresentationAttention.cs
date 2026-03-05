using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Set background color to LightGray
            slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            slide.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightGray;

            // Add a note to the slide
            Aspose.Slides.INotesSlideManager notesMgr = slide.NotesSlideManager;
            Aspose.Slides.INotesSlide notesSlide = notesMgr.AddNotesSlide();
            notesSlide.NotesTextFrame.Text = "This is a note for the slide.";

            // Set slide show type to PresentedBySpeaker
            presentation.SlideShowSettings.SlideShowType = new Aspose.Slides.PresentedBySpeaker();

            // Save the presentation
            presentation.Save("ManagedContent.ppt", Aspose.Slides.Export.SaveFormat.Ppt);
        }
    }
}