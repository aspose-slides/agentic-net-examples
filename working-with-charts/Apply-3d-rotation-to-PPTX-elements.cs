using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Verify command line arguments
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: program <input.pptx> <output.pptx>");
            return;
        }

        var inputPath = args[0];
        var outputPath = args[1];

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"Input file not found: {inputPath}");
            return;
        }

        // Load the presentation
        var presentation = new Aspose.Slides.Presentation(inputPath);

        // Get the first slide
        var slide = presentation.Slides[0];

        // Add a rectangle shape to the slide
        var shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 200);

        // Apply 3D rotation and lighting effects
        shape.ThreeDFormat.Depth = 5;
        shape.ThreeDFormat.Camera.SetRotation(30, 40, 0);
        shape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;
        shape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.Flat;
        shape.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}