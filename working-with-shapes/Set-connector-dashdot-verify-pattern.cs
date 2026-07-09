using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the shape collection of the first slide
        IShapeCollection shapes = presentation.Slides[0].Shapes;

        // Add an ellipse shape
        IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

        // Add a rectangle shape
        IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

        // Add a bent connector between the two shapes
        IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
        connector.StartShapeConnectedTo = ellipse;
        connector.EndShapeConnectedTo = rectangle;
        connector.Reroute();

        // Change the connector line dash style to DashDot
        connector.LineFormat.DashStyle = LineDashStyle.DashDot;

        // Verify the effective dash style
        ILineFormatEffectiveData effectiveLineFormat = connector.LineFormat.GetEffective();
        Console.WriteLine("Effective DashStyle: " + effectiveLineFormat.DashStyle);

        // Save the presentation
        string outputPath = "ConnectorDashDot.pptx";
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}