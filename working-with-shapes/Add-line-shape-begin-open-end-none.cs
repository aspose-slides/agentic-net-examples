using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "LineShape.pptx";
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.IAutoShape line = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 50, 150, 300, 0);
            line.LineFormat.BeginArrowheadStyle = Aspose.Slides.LineArrowheadStyle.Open;
            line.LineFormat.EndArrowheadStyle = Aspose.Slides.LineArrowheadStyle.None;
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}