using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Render3DShapesToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output directory and file paths
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);
            string pptxPath = Path.Combine(outputDir, "3DShape.pptx");
            string pngPath = Path.Combine(outputDir, "3DShape.png");

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a rectangle shape and configure it as a 3D shape
            Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 200, 150, 200, 200);
            shape.TextFrame.Text = "3D";
            shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

            // Set 3D formatting properties
            shape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;
            shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
            shape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.Flat;
            shape.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;
            shape.ThreeDFormat.Material = Aspose.Slides.MaterialPresetType.Flat;
            shape.ThreeDFormat.ExtrusionHeight = 100;
            shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

            // Render the first slide to a PNG image with scaling
            Aspose.Slides.IImage slideImage = presentation.Slides[0].GetImage(2f, 2f);
            slideImage.Save(pngPath, Aspose.Slides.ImageFormat.Png);

            // Save the presentation to PPTX format
            presentation.Save(pptxPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation object
            presentation.Dispose();
        }
    }
}