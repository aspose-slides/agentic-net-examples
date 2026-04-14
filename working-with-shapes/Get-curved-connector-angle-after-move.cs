using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConnectorAngleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "ConnectorAngleDemo.pptx";

            // Ensure any existing file is deleted before creating a new one
            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }

            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add two shapes to connect
                IAutoShape ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 100, 100, 100);
                IAutoShape rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 250, 120, 80);

                // Add a curved connector (BentConnector2)
                IConnector connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
                connector.StartShapeConnectedTo = ellipse;
                connector.EndShapeConnectedTo = rectangle;
                connector.Reroute();

                // Move the connected shapes to new positions
                ellipse.X = 150;
                ellipse.Y = 200;
                rectangle.X = 400;
                rectangle.Y = 350;

                // Reroute connector after moving shapes
                connector.Reroute();

                // Retrieve angle of the connector using its geometry
                double angle = GetConnectorAngle(connector);

                // Output the angle to console
                Console.WriteLine("Connector angle after moving shapes: {0} degrees", angle);

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported comment
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        // Helper method to calculate connector angle based on its width, height and flip flags
        private static double GetConnectorAngle(IConnector connector)
        {
            // Width and Height are in points
            float width = connector.Width;
            float height = connector.Height;

            // Determine flip status
            bool flipH = Convert.ToBoolean(connector.Frame.FlipH);
            bool flipV = Convert.ToBoolean(connector.Frame.FlipV);

            // Calculate base angle in degrees
            double radians = Math.Atan2(height, width);
            double degrees = radians * (180.0 / Math.PI);

            // Adjust angle based on flips
            if (flipH)
            {
                degrees = 180 - degrees;
            }
            if (flipV)
            {
                degrees = -degrees;
            }

            // Normalize angle to [0,360)
            while (degrees < 0)
            {
                degrees += 360;
            }
            while (degrees >= 360)
            {
                degrees -= 360;
            }

            return degrees;
        }
    }
}