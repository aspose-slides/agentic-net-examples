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

        // Add a rectangle auto shape
        Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);

        // Add a text frame to the shape
        autoShape.AddTextFrame("");

        // Get the first paragraph in the text frame
        Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

        // Create a new portion with text
        Aspose.Slides.IPortion portion = new Aspose.Slides.Portion("Formatted text");

        // Add the portion to the paragraph
        paragraph.Portions.Add(portion);

        // Access the portion format to apply character formatting
        Aspose.Slides.IPortionFormat portionFormat = portion.PortionFormat;

        // Set font size
        portionFormat.FontHeight = 24;

        // Set bold and italic
        portionFormat.FontBold = Aspose.Slides.NullableBool.True;
        portionFormat.FontItalic = Aspose.Slides.NullableBool.True;

        // Set underline
        portionFormat.FontUnderline = Aspose.Slides.TextUnderlineType.Single;

        // Set text fill color (e.g., red)
        Aspose.Slides.IFillFormat fillFormat = portionFormat.FillFormat;
        fillFormat.SolidFillColor.Color = System.Drawing.Color.Red;

        // Save the presentation
        presentation.Save("PortionFormatting_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}