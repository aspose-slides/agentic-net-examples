using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Apply3DGradientFill
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add an ellipse shape
            Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Ellipse,
                100,   // X position
                100,   // Y position
                300,   // Width
                200);  // Height

            // Apply gradient fill to the shape
            shape.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
            shape.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Linear;
            shape.FillFormat.GradientFormat.GradientDirection = Aspose.Slides.GradientDirection.FromCorner2;
            shape.FillFormat.GradientFormat.GradientStops.Add(0, Aspose.Slides.PresetColor.Purple);
            shape.FillFormat.GradientFormat.GradientStops.Add(100, Aspose.Slides.PresetColor.Red);

            // Apply 3D formatting
            shape.ThreeDFormat.Depth = 5;
            shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
            shape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;
            shape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.ThreePt;
            shape.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;

            // Save the presentation
            pres.Save("3DGradientShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}