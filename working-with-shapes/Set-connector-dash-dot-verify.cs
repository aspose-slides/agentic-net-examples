using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the shapes collection of the first slide
        IShapeCollection shapes = presentation.Slides[0].Shapes;

        // Add two shapes to connect
        IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
        IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 200, 300, 100, 100);

        // Add a connector shape
        IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
        connector.StartShapeConnectedTo = ellipse;
        connector.EndShapeConnectedTo = rectangle;
        connector.Reroute();

        // Change line dash style to DashDot
        connector.LineFormat.DashStyle = LineDashStyle.DashDot;

        // Verify effective dash pattern
        ILineFormatEffectiveData effective = connector.LineFormat.GetEffective();
        if (effective.DashStyle == LineDashStyle.DashDot)
        {
            Console.WriteLine("Connector dash style set to DashDot successfully.");
        }
        else
        {
            Console.WriteLine("Failed to set connector dash style.");
        }

        // Save the presentation
        string outputPath = "ConnectorDashDot.pptx";
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}