using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);
            // Update legend position to bottom‑right corner
            chart.Legend.Position = Aspose.Slides.Charts.LegendPositionType.Bottom;
            chart.Legend.X = 1.0f; // right edge (fraction of chart width)
            chart.Legend.Y = 1.0f; // bottom edge (fraction of chart height)
            presentation.Save("LegendBottomRight.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format or external resource errors)
        }
    }
}