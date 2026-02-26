using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape to the slide
        slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);

        // Add a notes slide with some text
        Aspose.Slides.INotesSlideManager notesManager = slide.NotesSlideManager;
        Aspose.Slides.INotesSlide notesSlide = notesManager.AddNotesSlide();
        notesSlide.NotesTextFrame.Text = "This is a note for the slide.";

        // Save the presentation in PPT format
        presentation.Save("LivePresentation.ppt", Aspose.Slides.Export.SaveFormat.Ppt);

        // Dispose the presentation object
        presentation.Dispose();
    }
}