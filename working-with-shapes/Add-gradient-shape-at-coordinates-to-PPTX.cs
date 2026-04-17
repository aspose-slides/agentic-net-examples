using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add an ellipse shape at specific coordinates (x=100, y=100, width=200, height=100)
            Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Ellipse, 100f, 100f, 200f, 100f);

            // Adjust the first adjustment handle (if available) – set its angle value
            if (shape.Adjustments.Count > 0)
            {
                shape.Adjustments[0].AngleValue = 45f; // Example angle in degrees
            }

            // Set gradient fill for the shape
            shape.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
            shape.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Linear;
            shape.FillFormat.GradientFormat.GradientDirection = Aspose.Slides.GradientDirection.FromCorner2;
            shape.FillFormat.GradientFormat.GradientStops.Add(0f, Aspose.Slides.PresetColor.Purple);
            shape.FillFormat.GradientFormat.GradientStops.Add(1f, Aspose.Slides.PresetColor.Red);

            // Save the presentation
            string outputPath = "CustomGradientShape.pptx";
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}