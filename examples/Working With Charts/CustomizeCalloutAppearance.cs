using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a callout shape to the slide
        Aspose.Slides.IAutoShape callout = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Callout1, 100, 100, 300, 150);

        // Set callout text
        callout.TextFrame.Text = "Custom Callout";

        // Customize fill color
        callout.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        callout.FillFormat.SolidFillColor.Color = Color.LightYellow;

        // Customize line style
        callout.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        callout.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
        callout.LineFormat.Width = 2;

        // Save the presentation
        presentation.Save("CustomCallout.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}