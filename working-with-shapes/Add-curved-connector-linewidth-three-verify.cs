using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add a curved connector to the slide
        IConnector connector = slide.Shapes.AddConnector(ShapeType.CurvedConnector2, 100, 100, 300, 0);

        // Set the line width to three points
        connector.LineFormat.Width = 3;

        // Verify that the line width is set correctly (visual verification would be manual)
        if (connector.LineFormat.Width == 3)
        {
            // Thickness is as expected
        }

        // Save the presentation before exiting
        presentation.Save("CurvedConnector.pptx", SaveFormat.Pptx);
    }
}