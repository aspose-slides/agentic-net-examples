using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddCustomLineCap
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                var presentation = new Presentation();

                // Get the first slide
                var slide = presentation.Slides[0];

                // Add a line shape
                var line = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

                // Set line width
                line.LineFormat.Width = 5;

                // Set custom line cap style for both ends
                line.LineFormat.CapStyle = LineCapStyle.Square;

                // Save the presentation
                var outputPath = "CustomLineCap.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}