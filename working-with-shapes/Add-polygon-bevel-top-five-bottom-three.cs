using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Presentation pres = new Presentation())
        {
            // Add a pentagon shape (used as a polygon substitute)
            IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Pentagon, 100f, 100f, 200f, 200f);

            // Configure the top bevel (5 points simulated by height and width of 5)
            shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Convex;
            shape.ThreeDFormat.BevelTop.Height = 5;
            shape.ThreeDFormat.BevelTop.Width = 5;

            // Configure the bottom bevel (3 points simulated by height and width of 3)
            shape.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Convex;
            shape.ThreeDFormat.BevelBottom.Height = 3;
            shape.ThreeDFormat.BevelBottom.Width = 3;

            // Save the presentation
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}