using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConnectorAngleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a curved connector to the slide
            IConnector connector = slide.Shapes.AddConnector(ShapeType.CurvedConnector2, 100, 100, 200, 0);

            // Retrieve the line angle of the connector
            double lineAngle = GetDirection(
                connector.Width,
                connector.Height,
                System.Convert.ToBoolean(connector.Frame.FlipH),
                System.Convert.ToBoolean(connector.Frame.FlipV));

            // Save the presentation
            presentation.Save("CurvedConnectorAngle.pptx", SaveFormat.Pptx);
        }

        // Helper method to calculate direction angle based on shape dimensions and flip flags
        private static double GetDirection(float width, float height, bool flipH, bool flipV)
        {
            double angle = Math.Atan2(height, width) * (180.0 / Math.PI);

            // Adjust angle based on horizontal flip
            if (flipH)
            {
                angle = 180 - angle;
            }

            // Adjust angle based on vertical flip
            if (flipV)
            {
                angle = -angle;
            }

            // Normalize angle to [0,360)
            if (angle < 0)
            {
                angle += 360;
            }

            return angle;
        }
    }
}