using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a five‑pointed star shape
        Aspose.Slides.IAutoShape star = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.FivePointedStar, 100, 100, 200, 200);

        // Apply a three‑stop gradient fill (blue → green → yellow)
        star.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
        Aspose.Slides.IGradientFormat gradient = star.FillFormat.GradientFormat;
        gradient.GradientShape = Aspose.Slides.GradientShape.Linear;
        gradient.GradientStops.Add(0f, System.Drawing.Color.Blue);
        gradient.GradientStops.Add(0.5f, System.Drawing.Color.Green);
        gradient.GradientStops.Add(1f, System.Drawing.Color.Yellow);

        // Save the presentation
        try
        {
            presentation.Save("StarGradient.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.Exception)
        {
            // Format not supported or other error
        }
    }
}