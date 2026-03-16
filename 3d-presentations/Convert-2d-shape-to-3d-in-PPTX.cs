using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace TransformShape3D
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a rectangle shape (2D)
                IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 150);

                // Set visual attributes
                shape.FillFormat.FillType = FillType.Solid;
                shape.FillFormat.SolidFillColor.Color = Color.LightGray;
                shape.LineFormat.FillFormat.FillType = FillType.Solid;
                shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;

                // Apply 3D formatting
                shape.ThreeDFormat.Depth = 30;
                shape.ThreeDFormat.ExtrusionHeight = 50;
                shape.ThreeDFormat.Material = MaterialPresetType.Plastic;
                shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
                shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
                shape.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
                shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

                // Save the presentation
                presentation.Save("Transformed3D.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}