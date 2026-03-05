using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the shape collection of the first slide
        Aspose.Slides.IShapeCollection shapes = presentation.Slides[0].Shapes;

        // Add two shapes to be connected
        Aspose.Slides.IAutoShape shape1 = (Aspose.Slides.IAutoShape)shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 100, 100, 100);
        Aspose.Slides.IAutoShape shape2 = (Aspose.Slides.IAutoShape)shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 300, 200, 100, 100);

        // Add a connector shape (default type)
        Aspose.Slides.IConnector connector = shapes.AddConnector(Aspose.Slides.ShapeType.StraightConnector1, 0, 0, 10, 10);

        // Set the connector type:
        // Straight: ShapeType.StraightConnector1
        // Elbow (bent): ShapeType.BentConnector2
        // Curve: ShapeType.CurvedConnector2
        // Example: set to Elbow (bent) connector
        connector.ShapeType = Aspose.Slides.ShapeType.BentConnector2;

        // Connect the shapes
        connector.StartShapeConnectedTo = shape1;
        connector.EndShapeConnectedTo = shape2;
        connector.Reroute();

        // Save the presentation
        presentation.Save("ConnectorExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}