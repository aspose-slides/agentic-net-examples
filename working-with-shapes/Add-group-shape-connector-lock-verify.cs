using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define output file path
                string outputPath = "GroupConnectorDemo.pptx";

                // Create a new presentation
                Presentation pres = new Presentation();

                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a group shape to the slide
                IGroupShape group = slide.Shapes.AddGroupShape();

                // Add a rectangle inside the group (used as a shape to connect)
                IAutoShape rectangle = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 100, 100);

                // Add a connector inside the group
                IConnector connector = group.Shapes.AddConnector(ShapeType.BentConnector2, 10, 10, 50, 0);

                // Connect the connector to the rectangle
                connector.StartShapeConnectedTo = rectangle;
                connector.EndShapeConnectedTo = rectangle;
                connector.Reroute();

                // Lock the group to prevent adding new shapes
                group.GroupShapeLock.GroupingLocked = true;

                // Attempt to edit the connector after the group is locked
                // For example, change the line width
                connector.LineFormat.Width = 5;

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}