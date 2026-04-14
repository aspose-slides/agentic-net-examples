using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add two shapes to connect
                Aspose.Slides.IAutoShape ellipse = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Ellipse, 50, 100, 100, 100);
                Aspose.Slides.IAutoShape rectangle = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 250, 300, 100, 100);

                // Add a bent connector
                Aspose.Slides.IConnector connector = slide.Shapes.AddConnector(
                    Aspose.Slides.ShapeType.BentConnector2, 0, 0, 10, 10);

                // Connect the shapes
                connector.StartShapeConnectedTo = ellipse;
                connector.EndShapeConnectedTo = rectangle;

                // Enable adjustment handles (unlock them)
                connector.ConnectorLock.AdjustHandlesLocked = false;

                // Modify adjustment values (example: bend position X and Y)
                // Ensure the connector has at least two adjustments
                if (connector.Adjustments.Count >= 2)
                {
                    // First adjustment (ConnectorBendPositionX)
                    Aspose.Slides.IAdjustValue adjust1 = connector.Adjustments[0];
                    adjust1.RawValue = 5000; // Set raw value (example)

                    // Second adjustment (ConnectorBendPositionY)
                    Aspose.Slides.IAdjustValue adjust2 = connector.Adjustments[1];
                    adjust2.RawValue = 8000; // Set raw value (example)
                }

                // Reroute to apply changes
                connector.Reroute();

                // Save the presentation
                presentation.Save("ConnectorAdjustment.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., external URL issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}