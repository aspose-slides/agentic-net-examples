using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];
            var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Bubble, 50f, 50f, 600f, 400f, true);
            var series = chart.ChartData.Series[0];

            var errorBarsX = series.ErrorBarsXFormat;
            errorBarsX.IsVisible = true;
            errorBarsX.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Fixed;
            errorBarsX.Value = 0.5f;
            errorBarsX.Type = Aspose.Slides.Charts.ErrorBarType.Plus;
            errorBarsX.HasEndCap = true;

            var errorBarsY = series.ErrorBarsYFormat;
            errorBarsY.IsVisible = true;
            errorBarsY.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Percentage;
            errorBarsY.Value = 10f;
            errorBarsY.Format.Line.Width = 2;

            presentation.Save("ErrorBarsChart.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}