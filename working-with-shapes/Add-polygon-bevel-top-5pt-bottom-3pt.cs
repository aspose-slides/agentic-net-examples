using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PolygonBevelExample
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            try
            {
                // Add a pentagon shape as a polygon placeholder
                IAutoShape shape = slide.Shapes.AddAutoShape(
                    ShapeType.Pentagon, 100f, 100f, 200f, 200f);

                // Configure top bevel (5 points)
                shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.SoftRound;
                shape.ThreeDFormat.BevelTop.Height = 5.0;
                shape.ThreeDFormat.BevelTop.Width = 5.0;

                // Configure bottom bevel (3 points)
                shape.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.SoftRound;
                shape.ThreeDFormat.BevelBottom.Height = 3.0;
                shape.ThreeDFormat.BevelBottom.Width = 3.0;
            }
            catch (Exception)
            {
                // Format not supported or other error handling
            }

            // Save the presentation
            pres.Save("PolygonBevel.pptx", SaveFormat.Pptx);
        }
    }
}