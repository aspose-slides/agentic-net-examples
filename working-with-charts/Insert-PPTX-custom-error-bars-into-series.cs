using System;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = pres.Slides[0];
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ScatterWithSmoothLines,
                50f, 50f, 500f, 400f);
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

            // Configure X error bars
            series.ErrorBarsXFormat.Type = Aspose.Slides.Charts.ErrorBarType.Both;
            series.ErrorBarsXFormat.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Fixed;
            series.ErrorBarsXFormat.Value = 5f;

            // Configure Y error bars
            series.ErrorBarsYFormat.Type = Aspose.Slides.Charts.ErrorBarType.Both;
            series.ErrorBarsYFormat.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Fixed;
            series.ErrorBarsYFormat.Value = 5f;

            pres.Save("CustomErrorBars.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}