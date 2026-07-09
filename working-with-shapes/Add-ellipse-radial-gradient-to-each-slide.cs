using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Iterate through each slide in the presentation
        for (int i = 0; i < pres.Slides.Count; i++)
        {
            Aspose.Slides.ISlide slide = pres.Slides[i];

            // Add an ellipse shape to the slide
            Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 50, 50, 400, 300);

            // Apply a radial gradient fill to the ellipse
            shape.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
            shape.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Radial;

            // Define gradient stops (offsets from 0 to 1)
            shape.FillFormat.GradientFormat.GradientStops.Add(0, Aspose.Slides.PresetColor.Purple);
            shape.FillFormat.GradientFormat.GradientStops.Add(1, Aspose.Slides.PresetColor.Red);
        }

        // Save the modified presentation
        string outputPath = "OutputWithRadialGradientBackground.pptx";
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}