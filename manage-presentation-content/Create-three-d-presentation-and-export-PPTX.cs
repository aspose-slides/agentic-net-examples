using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ThreeDPresentationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
                {
                    // Add a rectangle shape to the first slide
                    Aspose.Slides.IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Rectangle, 200, 150, 250, 250);

                    // Set some text for the shape
                    shape.TextFrame.Text = "3D Shape";

                    // Configure 3D format
                    shape.ThreeDFormat.Depth = 5.0;
                    shape.ThreeDFormat.ExtrusionHeight = 100.0;
                    shape.ThreeDFormat.Material = Aspose.Slides.MaterialPresetType.Plastic;
                    shape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;
                    shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
                    shape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.Flat;
                    shape.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;

                    // Set top bevel using a valid enum value (Cone does not exist)
                    shape.ThreeDFormat.BevelTop.BevelType = Aspose.Slides.BevelPresetType.Convex;
                    shape.ThreeDFormat.BevelTop.Height = 2.0;
                    shape.ThreeDFormat.BevelTop.Width = 2.0;

                    // Set bottom bevel
                    shape.ThreeDFormat.BevelBottom.BevelType = Aspose.Slides.BevelPresetType.SoftRound;
                    shape.ThreeDFormat.BevelBottom.Height = 1.5;
                    shape.ThreeDFormat.BevelBottom.Width = 1.5;

                    // Set extrusion color
                    shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

                    // Save the presentation as PPTX
                    pres.Save("ThreeDPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}