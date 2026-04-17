using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BevelEffectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add an ellipse shape
                Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Ellipse,
                    100, 100, 200, 200);

                // Set fill color
                shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                shape.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;

                // Set line format
                shape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                shape.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;
                shape.LineFormat.Width = 2.0;

                // Apply 3D bevel effect
                shape.ThreeDFormat.Depth = 5;
                shape.ThreeDFormat.BevelTop.BevelType = Aspose.Slides.BevelPresetType.Circle;
                shape.ThreeDFormat.BevelTop.Height = 5;
                shape.ThreeDFormat.BevelTop.Width = 5;
                shape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;
                shape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.ThreePt;
                shape.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;

                // Save the presentation
                presentation.Save("BevelEffectPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}