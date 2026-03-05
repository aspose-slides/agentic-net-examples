using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle autoshape
        Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 30, 30, 350, 100);

        // Create a text portion
        Aspose.Slides.Portion portion = new Aspose.Slides.Portion("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
        portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;

        // Add the portion to the shape's text frame
        autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

        // Set autofit mode to fit text within the shape
        Aspose.Slides.ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
        textFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.Shape;

        // Save the presentation as PPTX
        presentation.Save("AutoFitPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}