using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a group shape to the slide
        Aspose.Slides.IGroupShape group = slide.Shapes.AddGroupShape();

        // Add a rectangle inside the group (placeholder shape)
        Aspose.Slides.IAutoShape rectangle = group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 0, 0, 100, 100);

        // Add a connector inside the group
        Aspose.Slides.IConnector connector = group.Shapes.AddConnector(Aspose.Slides.ShapeType.BentConnector2, 10, 10, 50, 0);

        // Connect the connector to the rectangle
        connector.StartShapeConnectedTo = rectangle;
        connector.EndShapeConnectedTo = rectangle;
        connector.Reroute();

        // Lock the group to prevent adding new shapes
        group.GroupShapeLock.GroupingLocked = true;

        // Attempt to edit the connector after the group is locked
        try
        {
            connector.Width = 200;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Editing connector failed: " + ex.Message);
        }

        // Save the presentation
        presentation.Save("GroupConnectorDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}