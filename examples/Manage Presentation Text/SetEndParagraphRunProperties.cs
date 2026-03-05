using System;

class Program
{
    static void Main(string[] args)
    {
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
        Aspose.Slides.IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 10, 10, 200, 250);

        Aspose.Slides.Paragraph para1 = new Aspose.Slides.Paragraph();
        para1.Portions.Add(new Aspose.Slides.Portion("First paragraph"));

        Aspose.Slides.Paragraph para2 = new Aspose.Slides.Paragraph();
        para2.Portions.Add(new Aspose.Slides.Portion("Second paragraph"));

        Aspose.Slides.PortionFormat portionFormat = new Aspose.Slides.PortionFormat();
        portionFormat.FontHeight = 48;
        portionFormat.LatinFont = new Aspose.Slides.FontData("Arial");

        para2.EndParagraphPortionFormat = portionFormat;

        shape.TextFrame.Paragraphs.Add(para1);
        shape.TextFrame.Paragraphs.Add(para2);

        pres.Save("EndParagraphRunProperties_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}