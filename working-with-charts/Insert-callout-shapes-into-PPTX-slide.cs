using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "AnnotatedPresentation.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a callout shape
        Aspose.Slides.IAutoShape callout = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Callout1, 100, 100, 300, 150);
        callout.TextFrame.Text = "Important Note";

        // Set fill color
        callout.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        callout.FillFormat.SolidFillColor.Color = Color.Yellow;

        // Set line color
        callout.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        callout.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
        callout.LineFormat.Width = 2;

        // Add a target shape
        Aspose.Slides.IAutoShape target = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 400, 200, 100, 50);
        target.TextFrame.Text = "Target";

        // Add a connector from callout to target
        Aspose.Slides.IConnector connector = slide.Shapes.AddConnector(Aspose.Slides.ShapeType.Line, 0, 0, 10, 10);
        connector.StartShapeConnectedTo = callout;
        connector.EndShapeConnectedTo = target;
        connector.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
        connector.LineFormat.Width = 1.5f;
        connector.Reroute();

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}