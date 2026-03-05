using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access and modify document properties
        Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;
        docProps.Author = "John Doe";
        docProps.Title = "Managed Presentation";
        docProps.Subject = "Aspose.Slides Demo";
        docProps.Comments = "Created using Aspose.Slides for .NET";

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape with text
        Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
        autoShape.TextFrame.Text = "Hello Aspose.Slides!";

        // Save the presentation
        presentation.Save("ManagedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}