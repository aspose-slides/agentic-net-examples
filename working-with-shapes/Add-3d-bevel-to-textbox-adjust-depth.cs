using System;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add an ellipse shape that will serve as a 3‑D text box
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Ellipse, 100, 100, 400, 200);

        // Set solid fill and line colors
        shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        shape.FillFormat.SolidFillColor.Color = Color.LightBlue;
        shape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
        shape.LineFormat.Width = 2.0;

        // Add text to the shape
        shape.AddTextFrame("3‑D Bevel Text");
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 48;

        // Apply 3‑D bevel effect and adjust depth for realism
        shape.ThreeDFormat.Depth = 30;
        shape.ThreeDFormat.BevelTop.BevelType = Aspose.Slides.BevelPresetType.Circle;
        shape.ThreeDFormat.BevelTop.Height = 5;
        shape.ThreeDFormat.BevelTop.Width = 5;
        shape.ThreeDFormat.BevelBottom.BevelType = Aspose.Slides.BevelPresetType.Circle;
        shape.ThreeDFormat.BevelBottom.Height = 5;
        shape.ThreeDFormat.BevelBottom.Width = 5;

        // Configure camera and lighting for a realistic 3‑D appearance
        shape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;
        shape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.ThreePt;
        shape.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;

        // Save the presentation
        presentation.Save("BevelTextBox.pptx", SaveFormat.Pptx);
    }
}