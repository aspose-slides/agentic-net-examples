using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ThreeDGradientExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add an ellipse shape
            Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Ellipse,
                100,   // X position
                100,   // Y position
                300,   // Width
                200);  // Height

            // Apply gradient fill to the shape
            shape.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
            shape.FillFormat.GradientFormat.GradientStops.Add(0, Aspose.Slides.PresetColor.Blue);
            shape.FillFormat.GradientFormat.GradientStops.Add(100, Aspose.Slides.PresetColor.Orange);
            shape.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Linear;
            shape.FillFormat.GradientFormat.GradientDirection = Aspose.Slides.GradientDirection.FromCorner2;

            // Apply 3‑D properties
            shape.ThreeDFormat.Depth = 5;
            shape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;
            shape.ThreeDFormat.Camera.SetRotation(20, 30, 0);
            shape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.Flat;
            shape.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;

            // Save the presentation
            presentation.Save("ThreeDGradient.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}