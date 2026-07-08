using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Presentation();

        // Access the shape collection of the first slide
        var shapes = presentation.Slides[0].Shapes;

        // Add an ellipse and a rectangle
        var ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
        var rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 200, 300, 100, 100);

        // Add a bent connector
        var connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

        // Connect the shapes
        connector.StartShapeConnectedTo = ellipse;
        connector.EndShapeConnectedTo = rectangle;

        // Assign custom connection site indices if available
        uint startSiteIndex = 0;
        if (ellipse.ConnectionSiteCount > (int)startSiteIndex)
        {
            connector.StartShapeConnectionSiteIndex = startSiteIndex;
        }

        uint endSiteIndex = 0;
        if (rectangle.ConnectionSiteCount > (int)endSiteIndex)
        {
            connector.EndShapeConnectionSiteIndex = endSiteIndex;
        }

        // Reroute the connector to the shortest path
        connector.Reroute();

        // Align shapes to the bottom to verify alignment
        Aspose.Slides.Util.SlideUtil.AlignShapes(Aspose.Slides.ShapesAlignmentType.AlignBottom, true, presentation.Slides[0]);

        // Save the presentation
        try
        {
            presentation.Save("ConnectedShapes.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex) when (ex is NotSupportedException)
        {
            // Format not supported
        }
    }
}