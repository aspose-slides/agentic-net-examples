using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add an ellipse shape
        IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 100, 300, 200);

        // Set solid fill color
        shape.FillFormat.FillType = FillType.Solid;
        shape.FillFormat.SolidFillColor.Color = Color.Blue;

        // Set line format
        shape.LineFormat.FillFormat.FillType = FillType.Solid;
        shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
        shape.LineFormat.Width = 2.0;

        // Apply 3‑D bevel effect
        shape.ThreeDFormat.Depth = 3;
        shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
        shape.ThreeDFormat.BevelTop.Height = 5;
        shape.ThreeDFormat.BevelTop.Width = 5;
        shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
        shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
        shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

        // Prepare output directory
        string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Define PDF output path
        string pdfPath = Path.Combine(outputDir, "BevelEllipse.pdf");

        try
        {
            // Save the presentation as PDF
            presentation.Save(pdfPath, SaveFormat.Pdf);
        }
        catch (Exception)
        {
            // Format not supported
        }
    }
}