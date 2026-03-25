using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var chart = presentation.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.Bubble, 50f, 50f, 600f, 400f, true);
            var series = chart.ChartData.Series[0];
            var errBarX = series.ErrorBarsXFormat;
            errBarX.IsVisible = true;
            errBarX.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Custom;
            var errBarY = series.ErrorBarsYFormat;
            errBarY.IsVisible = true;
            errBarY.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Custom;
            var points = series.DataPoints;
            points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
            points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
            points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
            points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
            for (int i = 0; i < points.Count; i++)
            {
                points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
                points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
                points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
                points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
            }
            presentation.Save("CustomErrorBars.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}