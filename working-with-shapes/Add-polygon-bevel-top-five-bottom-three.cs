using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddPolygonBevel
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add a pentagon shape as a substitute for a generic polygon
            IAutoShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Pentagon,
                100f,   // X position
                100f,   // Y position
                200f,   // Width
                200f    // Height
            );

            // Configure top bevel (5 points approximated by height and width of 5)
            shape.ThreeDFormat.BevelTop.BevelType = Aspose.Slides.BevelPresetType.SoftRound;
            shape.ThreeDFormat.BevelTop.Height = 5.0;
            shape.ThreeDFormat.BevelTop.Width = 5.0;

            // Configure bottom bevel (3 points approximated by height and width of 3)
            shape.ThreeDFormat.BevelBottom.BevelType = Aspose.Slides.BevelPresetType.Angle;
            shape.ThreeDFormat.BevelBottom.Height = 3.0;
            shape.ThreeDFormat.BevelBottom.Width = 3.0;

            // Save the presentation
            pres.Save("PolygonBevel.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}