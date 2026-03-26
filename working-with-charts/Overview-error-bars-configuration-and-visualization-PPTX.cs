using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a scatter chart with smooth lines
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ScatterWithSmoothLines, 50, 50, 500, 400);

        // Access the first series of the chart
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // ----- Configure X error bars -----
        series.ErrorBarsXFormat.IsVisible = true;                                   // Show X error bars
        series.ErrorBarsXFormat.Type = Aspose.Slides.Charts.ErrorBarType.Both;      // Both directions
        series.ErrorBarsXFormat.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Fixed; // Fixed length
        series.ErrorBarsXFormat.Value = 0.5f;                                        // Fixed length value

        // ----- Configure Y error bars -----
        series.ErrorBarsYFormat.IsVisible = true;                                   // Show Y error bars
        series.ErrorBarsYFormat.Type = Aspose.Slides.Charts.ErrorBarType.Plus;      // Positive direction only
        series.ErrorBarsYFormat.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Percentage; // Percentage based
        series.ErrorBarsYFormat.Value = 10f;                                         // 10 percent of data value

        // ----- Add custom error bars for each data point -----
        Aspose.Slides.Charts.IErrorBarsFormat errorBarsX = series.ErrorBarsXFormat;
        Aspose.Slides.Charts.IErrorBarsFormat errorBarsY = series.ErrorBarsYFormat;

        // Switch to custom value type
        errorBarsX.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Custom;
        errorBarsY.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Custom;

        // Access data points collection
        Aspose.Slides.Charts.IChartDataPointCollection points = series.DataPoints;

        // Set data source type for custom values to literals
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;

        // Assign custom error values for each point
        for (int i = 0; i < points.Count; i++)
        {
            points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 0.2;
            points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 0.3;
            points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 0.1;
            points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 0.4;
        }

        // Save the presentation
        pres.Save("ErrorBarsOverview.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}