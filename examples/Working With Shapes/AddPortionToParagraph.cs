using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle AutoShape
        Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 100);

        // Add a TextFrame with placeholder text
        autoShape.AddTextFrame(" ");

        // Access the TextFrame
        Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

        // Get the first paragraph
        Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];

        // Get the first portion
        Aspose.Slides.IPortion portion = paragraph.Portions[0];

        // Set the text of the portion
        portion.Text = "Hello Aspose.Slides!";

        // Apply character formatting
        portion.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;
        portion.PortionFormat.FontHeight = 24f;
        portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

        // Save the presentation
        presentation.Save("Output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}