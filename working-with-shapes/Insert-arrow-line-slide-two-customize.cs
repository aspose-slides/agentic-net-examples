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
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Ensure there are at least two slides
            Aspose.Slides.ISlide firstSlide = pres.Slides[0];
            Aspose.Slides.ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

            // Add an arrow‑shaped line to slide two (index 1)
            Aspose.Slides.IAutoShape line = (Aspose.Slides.IAutoShape)secondSlide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Line, 50, 150, 300, 0);

            // Customize line format
            line.LineFormat.Style = Aspose.Slides.LineStyle.ThickBetweenThin;
            line.LineFormat.Width = 10;
            line.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.DashDot;
            line.LineFormat.BeginArrowheadLength = Aspose.Slides.LineArrowheadLength.Short;
            line.LineFormat.BeginArrowheadStyle = Aspose.Slides.LineArrowheadStyle.Oval;
            line.LineFormat.EndArrowheadLength = Aspose.Slides.LineArrowheadLength.Long;
            line.LineFormat.EndArrowheadStyle = Aspose.Slides.LineArrowheadStyle.Triangle;
            line.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            line.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Maroon;

            // Save the presentation
            pres.Save("ArrowLine.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format, I/O errors)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}