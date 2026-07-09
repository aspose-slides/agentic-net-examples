using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the shapes collection of the first slide
        Aspose.Slides.IShapeCollection shapes = presentation.Slides[0].Shapes;

        // Add an ellipse shape (provides connection sites)
        Aspose.Slides.IAutoShape ellipse = shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 50, 50, 100, 100);

        // Add an elbow (bent) connector
        Aspose.Slides.IConnector connector = shapes.AddConnector(Aspose.Slides.ShapeType.BentConnector2, 0, 0, 10, 10);

        // Connect the start of the connector to the ellipse
        connector.StartShapeConnectedTo = ellipse;

        // Set the start connection site to the third site (index 2)
        connector.StartShapeConnectionSiteIndex = 2;

        // Lock the connector to prevent editing points
        connector.ConnectorLock.EditPointsLocked = true;

        // Save the presentation
        string outputPath = "ConnectorExample.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}