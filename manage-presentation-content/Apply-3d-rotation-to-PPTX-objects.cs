using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load existing presentation if it exists, otherwise create a new one
        Aspose.Slides.Presentation presentation;
        if (File.Exists(inputPath))
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        else
        {
            presentation = new Aspose.Slides.Presentation();
        }

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape and apply 3D formatting
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 200);
        shape.TextFrame.Text = "3D Shape";
        shape.ThreeDFormat.Depth = 5;
        shape.ThreeDFormat.Material = Aspose.Slides.MaterialPresetType.Plastic;
        shape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.PerspectiveContrastingRightFacing;
        shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
        shape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.Balanced;
        shape.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;
        shape.ThreeDFormat.LightRig.SetRotation(0, 0, 45);

        // Add a chart and set its 3D rotation
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 350, 400, 300);
        chart.Rotation3D.RotationX = 30;
        chart.Rotation3D.RotationY = 45;

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}