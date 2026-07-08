using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace GradientStarExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a five-pointed star shape
                IAutoShape star = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.FivePointedStar,
                    100, 100, 300, 300);

                // Set the fill type to gradient
                star.FillFormat.FillType = FillType.Gradient;

                // Configure gradient shape (optional)
                star.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

                // Add gradient stops: blue at 0%, green at 50%, yellow at 100%
                star.FillFormat.GradientFormat.GradientStops.Add(0f, System.Drawing.Color.Blue);
                star.FillFormat.GradientFormat.GradientStops.Add(0.5f, System.Drawing.Color.Green);
                star.FillFormat.GradientFormat.GradientStops.Add(1f, System.Drawing.Color.Yellow);

                // Save the presentation
                presentation.Save("StarGradient.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("Error: " + ex.Message);
                // Format not supported comment
                // The requested file format may not be supported by the current Aspose.Slides version.
            }
        }
    }
}