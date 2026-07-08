using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add an ellipse shape
        Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 100, 100, 300, 200);

        // Set fill and line formatting
        shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        shape.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightBlue;
        shape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        shape.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.DarkBlue;
        shape.LineFormat.Width = 2.0;

        // Apply 3‑D bevel effect
        shape.ThreeDFormat.Depth = 5;
        shape.ThreeDFormat.BevelTop.BevelType = Aspose.Slides.BevelPresetType.Circle;
        shape.ThreeDFormat.BevelTop.Height = 4;
        shape.ThreeDFormat.BevelTop.Width = 4;
        shape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;
        shape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.ThreePt;
        shape.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;

        // Prepare output directory
        string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Define PDF output path
        string pdfPath = Path.Combine(outputDir, "EllipseBevel.pdf");

        // Save the presentation as PDF with exception handling
        try
        {
            presentation.Save(pdfPath, Aspose.Slides.Export.SaveFormat.Pdf);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            // Format not supported or other issue: ex.Message
        }
    }
}