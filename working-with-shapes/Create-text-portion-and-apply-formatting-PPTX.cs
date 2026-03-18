using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a rectangle auto shape
            IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.FillFormat.FillType = FillType.Solid;
            shape.FillFormat.SolidFillColor.Color = Color.LightGray;

            // Add an empty text frame to the shape
            shape.AddTextFrame("");

            // Create a paragraph
            IParagraph paragraph = new Paragraph();

            // First portion with normal styling
            IPortion portion1 = new Portion("Hello ");
            portion1.PortionFormat.FontHeight = 24f;
            portion1.PortionFormat.FontBold = NullableBool.True;
            portion1.PortionFormat.FontItalic = NullableBool.False;
            portion1.PortionFormat.FontUnderline = TextUnderlineType.Single;
            portion1.PortionFormat.LatinFont = new FontData("Arial");

            // Second portion with additional styling
            IPortion portion2 = new Portion("World!");
            portion2.PortionFormat.FontHeight = 24f;
            portion2.PortionFormat.FontBold = NullableBool.True;
            portion2.PortionFormat.FontItalic = NullableBool.True;
            portion2.PortionFormat.FontUnderline = TextUnderlineType.Double;
            portion2.PortionFormat.LatinFont = new FontData("Arial");
            portion2.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion2.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

            // Add portions to the paragraph
            paragraph.Portions.Add(portion1);
            paragraph.Portions.Add(portion2);

            // Add paragraph to the shape's text frame
            shape.TextFrame.Paragraphs.Add(paragraph);

            // Save the presentation
            presentation.Save("FormattedText.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}