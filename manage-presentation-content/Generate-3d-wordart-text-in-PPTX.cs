using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlides3DWordArt
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                var presentation = new Presentation();

                // Get the first slide
                var slide = presentation.Slides[0];

                // Add a rectangle auto shape to host the WordArt text
                var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 200);

                // Set the shape to have no fill and no line (transparent background)
                shape.FillFormat.FillType = FillType.NoFill;
                shape.LineFormat.FillFormat.FillType = FillType.NoFill;

                // Set the text for the WordArt
                shape.TextFrame.Text = "3D WordArt";

                // Apply a WordArt transform effect (e.g., Arch Up)
                shape.TextFrame.TextFrameFormat.Transform = TextShapeType.ArchUp;

                // Configure 3D formatting for the text
                var threeD = shape.TextFrame.TextFrameFormat.ThreeDFormat;
                threeD.ExtrusionHeight = 5; // Extrusion height
                threeD.Depth = 3; // Depth of the 3D effect
                threeD.Material = MaterialPresetType.Plastic; // Material type
                threeD.LightRig.LightType = LightRigPresetType.Balanced; // Light type
                threeD.LightRig.Direction = LightingDirection.Top; // Light direction
                threeD.LightRig.SetRotation(0, 0, 40); // Light rotation
                threeD.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing; // Camera type

                // Save the presentation
                presentation.Save("3DWordArt.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}