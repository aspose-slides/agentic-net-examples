using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

class Program
{
    static void Main()
    {
        try
        {
            // Load the presentation from a file
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Find two shapes by their alternative text
            Aspose.Slides.IShape shape1 = Aspose.Slides.Util.SlideUtil.FindShape(slide, "Shape1AltText");
            Aspose.Slides.IShape shape2 = Aspose.Slides.Util.SlideUtil.FindShape(slide, "Shape2AltText");

            if (shape1 != null && shape2 != null)
            {
                // Add a connector shape to the slide
                Aspose.Slides.IConnector connector = slide.Shapes.AddConnector(Aspose.Slides.ShapeType.BentConnector2, 0, 0, 10, 10);

                // Connect the connector to the two shapes
                connector.StartShapeConnectedTo = shape1;
                connector.EndShapeConnectedTo = shape2;

                // Recalculate the connector path
                connector.Reroute();
            }

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}