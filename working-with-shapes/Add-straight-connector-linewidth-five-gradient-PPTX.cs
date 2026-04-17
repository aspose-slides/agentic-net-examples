using System;
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

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Access the shapes collection of the slide
            IShapeCollection shapes = slide.Shapes;

            // Add a straight connector (using BentConnector2 as a straight line placeholder)
            IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 100, 100, 300, 0);

            // Set line width to five points
            connector.LineFormat.Width = 5;

            // Apply gradient fill to the connector line
            connector.LineFormat.FillFormat.FillType = FillType.Gradient;
            connector.LineFormat.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
            connector.LineFormat.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

            // Save the presentation
            string outputPath = "ConnectorGradient.pptx";
            try
            {
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle format not supported or other save errors
                // Format not supported
            }
        }
    }
}