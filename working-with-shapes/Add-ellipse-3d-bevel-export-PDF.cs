using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Prepare output directory
        string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Define file paths
        string pptxPath = Path.Combine(outputDir, "BevelEllipse.pptx");
        string pdfPath = Path.Combine(outputDir, "BevelEllipse.pdf");

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add an ellipse shape
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 100, 100, 300, 200);

        // Set fill and line formatting
        shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        shape.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;
        shape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        shape.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;
        shape.LineFormat.Width = 2.0;

        // Apply 3‑D bevel effect
        shape.ThreeDFormat.Depth = 3;
        shape.ThreeDFormat.BevelTop.BevelType = Aspose.Slides.BevelPresetType.Circle;
        shape.ThreeDFormat.BevelTop.Height = 5;
        shape.ThreeDFormat.BevelTop.Width = 5;
        shape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;
        shape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.ThreePt;
        shape.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;

        // Save as PPTX
        try
        {
            presentation.Save(pptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }

        // Save as PDF for review
        try
        {
            presentation.Save(pdfPath, Aspose.Slides.Export.SaveFormat.Pdf);
        }
        catch (Exception)
        {
            // Format not supported
        }
    }
}