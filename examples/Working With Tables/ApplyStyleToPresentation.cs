using System;
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

        // Add a rectangle shape
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 150, 75, 400, 300);

        // Set shape fill to no fill
        shape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

        // Add a text frame with sample text
        shape.AddTextFrame("Hello Aspose!");

        // Get the first portion of the text
        Aspose.Slides.IPortion portion = shape.TextFrame.Paragraphs[0].Portions[0];
        Aspose.Slides.IPortionFormat portionFormat = portion.PortionFormat;

        // Set font height
        portionFormat.FontHeight = 48;

        // Enable inner shadow effect and configure it
        Aspose.Slides.IEffectFormat effectFormat = portionFormat.EffectFormat;
        effectFormat.EnableInnerShadowEffect();
        effectFormat.InnerShadowEffect.BlurRadius = 5;
        effectFormat.InnerShadowEffect.Direction = 45;
        effectFormat.InnerShadowEffect.Distance = 3;
        effectFormat.InnerShadowEffect.ShadowColor.B = 0;
        effectFormat.InnerShadowEffect.ShadowColor.ColorType = Aspose.Slides.ColorType.Scheme;
        effectFormat.InnerShadowEffect.ShadowColor.SchemeColor = Aspose.Slides.SchemeColor.Accent1;

        // Save the presentation
        string outPath = "StyledPresentation.pptx";
        presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}