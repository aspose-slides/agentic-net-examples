using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (Presentation presentation = new Presentation())
            {
                ISlide slide = presentation.Slides[0];

                // Add two shapes to connect
                IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 100, 50);
                IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 300, 150, 100, 50);

                // Add a straight connector
                IConnector connector = slide.Shapes.AddConnector(ShapeType.StraightConnector1, 0, 0, 10, 10);

                // Connect the shapes
                connector.StartShapeConnectedTo = shape1;
                connector.EndShapeConnectedTo = shape2;

                // Apply dashed line style
                connector.LineFormat.DashStyle = LineDashStyle.Dash;

                // Adjust the first adjustment point (e.g., bend position X)
                if (connector.Adjustments.Count > 0)
                {
                    // RawValue expects an Int64; 50000 represents 50% of the shape's dimension
                    connector.Adjustments[0].RawValue = 50000;
                }

                // Save the presentation
                presentation.Save("DashedConnector.pptx", SaveFormat.Pptx);
            }
        }
        catch (System.IO.FileNotFoundException ex)
        {
            Console.WriteLine("File not found: " + ex.Message);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}