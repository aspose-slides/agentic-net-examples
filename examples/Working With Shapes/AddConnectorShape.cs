using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a connector shape to the slide
        Aspose.Slides.IConnector connector = slide.Shapes.AddConnector(
            Aspose.Slides.ShapeType.BentConnector2,
            0f, 0f, 10f, 10f);

        // Save the presentation
        presentation.Save("ConnectorExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}