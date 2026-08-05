// -----------------------------------------------------------------------------
// Example: Add group shape connector lock edit attempt using C#
//
// Description:
// Demonstrates how to add a group shape containing a rectangle and a connector,
// lock the group to prevent further modifications, and attempt to edit the
// connector after the lock is applied using C# and Aspose.Slides for .NET. The
// example shows the required presentation-processing steps for PowerPoint files
// and produces the requested output in a standalone console application.
// Developers can use this pattern to automate PPTX workflows, test lock
// behavior, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Group Shape, Connector, Lock,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a group shape with a connector and applying a lock.
// - Build C# tools for PowerPoint presentation processing and lock testing.
// - Generate or transform PPTX files in .NET applications.
// - Validate group lock behavior before publishing or integration.
// -----------------------------------------------------------------------------

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
