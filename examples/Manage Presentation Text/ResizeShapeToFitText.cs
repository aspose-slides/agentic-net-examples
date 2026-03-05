using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Load or create a presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle autoshape
        Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 30, 30, 350, 100);

        // Create a text portion and set its formatting
        Aspose.Slides.IPortion portion = new Aspose.Slides.Portion(
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;

        // Add the portion to the shape's text frame
        autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

        // Set autofit mode so the shape resizes to fit the text
        Aspose.Slides.ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
        textFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.Shape;

        // Save the presentation
        presentation.Save("ResizedShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}