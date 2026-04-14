using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a rectangle shape
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);

        // Apply gradient fill to the rectangle
        shape.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
        shape.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Linear;
        shape.FillFormat.GradientFormat.GradientDirection = Aspose.Slides.GradientDirection.FromCorner2;
        shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, Aspose.Slides.PresetColor.Purple);
        shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, Aspose.Slides.PresetColor.Red);

        // Retrieve effective fill format data
        Aspose.Slides.IFillFormatEffectiveData effectiveFill = shape.FillFormat.GetEffective();

        if (effectiveFill.FillType == Aspose.Slides.FillType.Gradient)
        {
            Aspose.Slides.IGradientFormatEffectiveData gradEff = effectiveFill.GradientFormat;
            float angle = gradEff.LinearGradientAngle;
            int stopsCount = gradEff.GradientStops.Count;

            Console.WriteLine("Effective Gradient Angle: " + angle);
            Console.WriteLine("Effective Gradient Stops Count: " + stopsCount);

            for (int i = 0; i < stopsCount; i++)
            {
                Aspose.Slides.IGradientStopEffectiveData stop = gradEff.GradientStops[i];
                Console.WriteLine("Stop " + i + ": Position=" + stop.Position + ", Color=" + stop.Color);
            }
        }

        // Save the presentation
        string outputPath = "GradientRectangle.pptx";
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}