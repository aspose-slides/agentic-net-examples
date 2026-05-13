using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Presentation pres = new Presentation();
            ISlide slide = pres.Slides[0];
            IAutoShape line = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
            line.LineFormat.Style = LineStyle.ThickBetweenThin;
            line.LineFormat.Width = 10;
            line.LineFormat.DashStyle = LineDashStyle.DashDot;
            line.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
            line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Open;
            line.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
            line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
            line.LineFormat.FillFormat.FillType = FillType.Solid;
            line.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;
            string outputPath = "LineShape.pptx";
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}