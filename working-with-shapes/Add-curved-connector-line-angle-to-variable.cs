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

        // Add a curved connector to the slide
        Aspose.Slides.IConnector connector = slide.Shapes.AddConnector(Aspose.Slides.ShapeType.CurvedConnector2, 100, 100, 200, 0);

        // Set a simple line width
        connector.LineFormat.Width = 5;

        // Calculate the line angle (in degrees) based on connector dimensions
        double angleRadians = Math.Atan2(connector.Height, connector.Width);
        double angleDegrees = angleRadians * (180.0 / Math.PI);
        double connectorLineAngle = angleDegrees; // Store the angle

        // Save the presentation
        string outputPath = "CurvedConnectorAngle.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}