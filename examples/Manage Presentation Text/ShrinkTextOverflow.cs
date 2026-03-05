using System;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Load an existing PPTX file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle AutoShape to the slide
        Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 30, 30, 350, 100);

        // Create a text portion with long content
        Aspose.Slides.Portion portion = new Aspose.Slides.Portion(
            "This is a very long text that should shrink on overflow.");

        // Set text color to black and fill type to solid
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
        portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;

        // Add the portion to the shape's text frame
        autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

        // Configure the text frame to shrink text on overflow
        Aspose.Slides.ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
        textFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.Normal;

        // Save the modified presentation
        presentation.Save("output.pptx", SaveFormat.Pptx);
    }
}