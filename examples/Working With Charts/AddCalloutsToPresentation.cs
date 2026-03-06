using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a callout shape to the slide
        Aspose.Slides.IAutoShape callout = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Callout1, 100, 100, 300, 100);

        // Set the text of the callout
        callout.TextFrame.Text = "This is a callout";

        // Set fill color for the callout
        callout.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        callout.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightYellow;

        // Set line format for the callout
        callout.LineFormat.Width = 2;
        callout.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        callout.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

        // Save the presentation to a file
        presentation.Save("CalloutPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}