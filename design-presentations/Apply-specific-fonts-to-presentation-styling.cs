using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add two rectangle AutoShapes with text
            Aspose.Slides.IAutoShape shape1 = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
            shape1.AddTextFrame("First Font Text");
            Aspose.Slides.IAutoShape shape2 = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 200, 400, 100);
            shape2.AddTextFrame("Second Font Text");

            // Access the text frames
            Aspose.Slides.ITextFrame tf1 = shape1.TextFrame;
            Aspose.Slides.ITextFrame tf2 = shape2.TextFrame;

            // Access the first paragraph and portion of each text frame
            Aspose.Slides.IParagraph para1 = tf1.Paragraphs[0];
            Aspose.Slides.IParagraph para2 = tf2.Paragraphs[0];
            Aspose.Slides.IPortion port1 = para1.Portions[0];
            Aspose.Slides.IPortion port2 = para2.Portions[0];

            // Set font properties for the first portion
            port1.PortionFormat.LatinFont = new Aspose.Slides.FontData("Arial");
            port1.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;
            port1.PortionFormat.FontItalic = Aspose.Slides.NullableBool.True;
            port1.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            port1.PortionFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;

            // Set font properties for the second portion
            port2.PortionFormat.LatinFont = new Aspose.Slides.FontData("Times New Roman");
            port2.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;
            port2.PortionFormat.FontItalic = Aspose.Slides.NullableBool.True;
            port2.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            port2.PortionFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;

            // Save the presentation
            presentation.Save("StyledFontsPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}