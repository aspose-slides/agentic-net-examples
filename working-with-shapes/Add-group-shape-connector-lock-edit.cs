using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.IO;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = "GroupConnectorDemo.pptx";

        // Create a new presentation
        Presentation pres = new Presentation();

        // Get the first slide
        ISlide slide = pres.Slides[0];

        // Add a group shape to the slide
        IGroupShape group = slide.Shapes.AddGroupShape();

        // Add a rectangle shape inside the group
        IAutoShape rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

        // Add a connector shape inside the group
        IConnector connector = group.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

        // Connect the connector to the rectangle
        connector.StartShapeConnectedTo = rect;

        // Lock the group to prevent adding new shapes
        group.GroupShapeLock.GroupingLocked = true;

        // Attempt to edit the connector after the group is locked
        if (connector.ConnectionSiteCount > 0)
        {
            connector.StartShapeConnectionSiteIndex = 0;
        }

        // Save the presentation
        try
        {
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }

        // Clean up
        pres.Dispose();
    }
}