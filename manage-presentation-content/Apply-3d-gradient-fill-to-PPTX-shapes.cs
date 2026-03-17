using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace ThreeDGradientExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

                // Add a rectangle shape
                Aspose.Slides.IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 200, 150, 250, 250);

                // Set shape text
                shape.TextFrame.Text = "3D Gradient";

                // Apply gradient fill
                shape.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
                shape.FillFormat.GradientFormat.GradientStops.Add(0, Color.Blue);
                shape.FillFormat.GradientFormat.GradientStops.Add(100, Color.Orange);

                // Configure 3D format
                shape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;
                shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
                shape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.Flat;
                shape.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;
                shape.ThreeDFormat.Material = Aspose.Slides.MaterialPresetType.Flat;
                shape.ThreeDFormat.ExtrusionHeight = 100;
                shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

                // Save the presentation
                pres.Save("ThreeDGradientShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}