using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        Aspose.Slides.IAutoShape line = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 50, 150, 300, 0);
        line.LineFormat.BeginArrowheadStyle = Aspose.Slides.LineArrowheadStyle.None;
        line.LineFormat.EndArrowheadStyle = Aspose.Slides.LineArrowheadStyle.Diamond;
        line.LineFormat.Width = 5;
        string outputPath = "LineWithDiamondArrow.pptx";
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
        finally
        {
            presentation.Dispose();
        }
    }
}