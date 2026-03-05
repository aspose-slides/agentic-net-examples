using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Set document properties to improve accessibility metadata
        Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;
        docProps.Title = "Accessible Presentation";
        docProps.Subject = "Demonstrates accessibility features";
        docProps.Author = "John Doe";

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape with alternative text for screen readers
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle,
            100, 100, 300, 150);
        shape.AlternativeText = "Important information box";

        // Add presenter notes to the slide
        Aspose.Slides.INotesSlideManager notesMgr = slide.NotesSlideManager;
        Aspose.Slides.INotesSlide notesSlide = notesMgr.AddNotesSlide();
        notesSlide.NotesTextFrame.Text = "Slide notes: Explain the content of the rectangle.";

        // Save the presentation before exiting
        presentation.Save("AccessiblePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}