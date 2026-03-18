using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load an existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Get the shapes collection of the slide
            Aspose.Slides.IShapeCollection shapes = slide.Shapes;

            // Add two shapes that will be connected
            Aspose.Slides.IAutoShape shape1 = shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50f, 100f, 100f, 100f);
            Aspose.Slides.IAutoShape shape2 = shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 300f, 200f, 100f, 100f);

            // Add a connector shape
            Aspose.Slides.IConnector connector = shapes.AddConnector(Aspose.Slides.ShapeType.BentConnector2, 0f, 0f, 10f, 10f);

            // Connect the shapes
            connector.StartShapeConnectedTo = shape1;
            connector.EndShapeConnectedTo = shape2;

            // Adjust the connector path
            connector.Reroute();

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}