using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add an auto shape (rectangle) at specific coordinates
        Aspose.Slides.IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);

        // Adjust shape handles (example: double the CornerSize if present)
        for (int i = 0; i < shape.Adjustments.Count; i++)
        {
            if (shape.Adjustments.Count > 0 && shape.Adjustments[0].Type == Aspose.Slides.ShapeAdjustmentType.CornerSize)
            {
                shape.Adjustments[0].AngleValue *= 2;
            }
        }

        // Apply a gradient fill to the shape
        shape.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
        shape.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Linear;
        shape.FillFormat.GradientFormat.GradientDirection = Aspose.Slides.GradientDirection.FromCorner2;
        shape.FillFormat.GradientFormat.GradientStops.Add(0, Aspose.Slides.PresetColor.Purple);
        shape.FillFormat.GradientFormat.GradientStops.Add(1, Aspose.Slides.PresetColor.Red);

        // Save the presentation
        string outputPath = "CustomShapeGradient.pptx";
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}