using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RoundedRectangleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "RoundedRectangle.pptx";

            // Create a new presentation
            Presentation pres = new Presentation();

            // Add a rectangle shape to the first slide
            IAutoShape rectShape = pres.Slides[0].Shapes.AddAutoShape(
                ShapeType.Rectangle, 100, 100, 300, 150);

            // Ensure the shape has at least one adjustment (corner size)
            if (rectShape.Adjustments.Count > 0 && rectShape.Adjustments[0].Type == ShapeAdjustmentType.CornerSize)
            {
                // Set initial corner radius (in points)
                rectShape.Adjustments[0].AngleValue = 5;

                // Increase corner radius by five points
                rectShape.Adjustments[0].AngleValue += 5;
            }

            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);

            // Clean up
            pres.Dispose();
        }
    }
}