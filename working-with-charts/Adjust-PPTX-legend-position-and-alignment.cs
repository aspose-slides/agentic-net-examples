using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AdjustLegend
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 400, 300);
                chart.HasLegend = true;
                // Set legend position using LegendPositionType enum
                chart.Legend.Position = Aspose.Slides.Charts.LegendPositionType.Right;
                // Optionally set custom coordinates (fraction of chart size)
                chart.Legend.X = 0.8f; // 80% from left
                chart.Legend.Y = 0.1f; // 10% from top
                // Save presentation
                presentation.Save("AdjustedLegend.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}