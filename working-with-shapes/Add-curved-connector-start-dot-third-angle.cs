using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (Presentation pres = new Presentation())
            {
                ISlide slide = pres.Slides[0];

                // Add a rectangle shape to provide connection sites
                IAutoShape rect = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

                // Add a curved connector
                IConnector connector = slide.Shapes.AddConnector(ShapeType.CurvedConnector2, 0, 0, 100, 100);

                // Set the start dot to the third connection site (index 2)
                connector.StartShapeConnectedTo = rect;
                connector.StartShapeConnectionSiteIndex = 2;

                // Compute the line angle based on the connector's bounding box
                double deltaX = connector.X + connector.Width - connector.X;
                double deltaY = connector.Y + connector.Height - connector.Y;
                double angleRadians = Math.Atan2(deltaY, deltaX);
                double angleDegrees = angleRadians * (180.0 / Math.PI);
                Console.WriteLine("Connector line angle: " + angleDegrees);

                // Save the presentation
                pres.Save("CurvedConnector.pptx", SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxException ex)
        {
            Console.WriteLine("PPTX format error: " + ex.Message);
        }
        catch (Aspose.Slides.PptException ex)
        {
            Console.WriteLine("PPT format error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}