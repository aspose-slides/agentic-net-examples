using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle autoshape
        Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 30, 30, 350, 100);

        // Create a portion with text
        Aspose.Slides.Portion portion = new Aspose.Slides.Portion("lorem ipsum dolor sit amet, consectetur adipiscing elit.");

        // Set text color
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
        portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;

        // Add portion to shape's text frame
        autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

        // Set autofit to shape (resize shape to fit text)
        Aspose.Slides.ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
        textFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.Shape;

        // Save the presentation
        presentation.Save("ResizedShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}