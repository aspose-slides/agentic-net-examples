using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
        {
            // Get the first slide (declare as ISlide per compiler rule)
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add two shapes to serve as connector endpoints
            Aspose.Slides.IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50f, 150f, 100f, 50f);
            Aspose.Slides.IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 300f, 150f, 100f, 50f);

            // Add a curved connector shape
            Aspose.Slides.IConnector connector = slide.Shapes.AddConnector(ShapeType.CurvedConnector2, 0f, 0f, 10f, 10f);

            // Connect the connector to the two shapes
            connector.StartShapeConnectedTo = shape1;
            connector.EndShapeConnectedTo = shape2;

            // Set the start dot to the third connection site (index is zero‑based)
            connector.StartShapeConnectionSiteIndex = 2;

            // Reroute the connector to compute the shortest path
            connector.Reroute();

            // Compute the line angle using the connector's rotation property
            float angle = connector.Rotation;
            System.Console.WriteLine("Connector line angle: " + angle);

            // Save the presentation before exiting
            pres.Save("CurvedConnector.pptx", SaveFormat.Pptx);
        }
    }
}