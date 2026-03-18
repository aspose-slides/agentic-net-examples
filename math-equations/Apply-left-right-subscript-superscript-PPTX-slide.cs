using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
            shape.AddTextFrame("");

            Aspose.Slides.Paragraph paragraph = new Aspose.Slides.Paragraph();

            Aspose.Slides.Portion portionH = new Aspose.Slides.Portion("H");
            Aspose.Slides.Portion portion2 = new Aspose.Slides.Portion("2");
            Aspose.Slides.Portion portionO = new Aspose.Slides.Portion("O");
            Aspose.Slides.Portion portionPlus = new Aspose.Slides.Portion("+");

            // Apply subscript to the left side ("2")
            portion2.PortionFormat.Escapement = -100f;
            // Apply superscript to the right side ("+")
            portionPlus.PortionFormat.Escapement = 100f;

            paragraph.Portions.Add(portionH);
            paragraph.Portions.Add(portion2);
            paragraph.Portions.Add(portionO);
            paragraph.Portions.Add(portionPlus);

            shape.TextFrame.Paragraphs.Add(paragraph);

            presentation.Save("SubSuperscript.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}