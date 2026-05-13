using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConnectorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Get the shape collection of the slide
            IShapeCollection shapes = slide.Shapes;

            // Add a straight connector to the slide
            IConnector connector = shapes.AddConnector(ShapeType.Line, 100, 100, 200, 0);

            // Set the line width to five points
            connector.LineFormat.Width = 5;

            // Apply a gradient fill to the connector line
            connector.LineFormat.FillFormat.FillType = FillType.Gradient;
            connector.LineFormat.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
            connector.LineFormat.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;
            // Add gradient stops (offset, color)
            connector.LineFormat.FillFormat.GradientFormat.GradientStops.Add(0, PresetColor.Blue);
            connector.LineFormat.FillFormat.GradientFormat.GradientStops.Add(1, PresetColor.Red);

            // Save the presentation
            string outputPath = "StraightConnectorGradient.pptx";
            try
            {
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file I/O)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}