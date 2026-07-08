using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConnectorAdjustmentDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the shape collection of the first slide
            IShapeCollection shapes = pres.Slides[0].Shapes;

            // Add an ellipse shape
            IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0f, 100f, 100f, 100f);

            // Add a rectangle shape
            IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100f, 300f, 100f, 100f);

            // Add a bent connector
            IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0f, 0f, 10f, 10f);

            // Connect the shapes
            connector.StartShapeConnectedTo = ellipse;
            connector.EndShapeConnectedTo = rectangle;

            // Enable and modify adjustment handles (connection site indices)
            if (ellipse.ConnectionSiteCount > 0)
            {
                connector.StartShapeConnectionSiteIndex = 0u; // first connection site of ellipse
            }

            if (rectangle.ConnectionSiteCount > 0)
            {
                connector.EndShapeConnectionSiteIndex = 0u; // first connection site of rectangle
            }

            // Reroute the connector to apply changes
            connector.Reroute();

            // Confirm new path shape by retrieving its geometry path (optional verification)
            IGeometryPath[] geometryPaths = ((IGeometryShape)connector).GetGeometryPaths();

            // Save the presentation
            string outputPath = "ConnectorAdjustmentDemo.pptx";
            pres.Save(outputPath, SaveFormat.Pptx);

            // Clean up
            pres.Dispose();
        }
    }
}