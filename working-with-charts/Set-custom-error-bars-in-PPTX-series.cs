using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a bubble chart to the first slide
        Aspose.Slides.Charts.IChart chart = pres.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Bubble,
            0, 0, 500, 400, true);

        // Get the first series of the chart
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Configure X error bars
        Aspose.Slides.Charts.IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
        errBarX.IsVisible = true;
        errBarX.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Custom;

        // Configure Y error bars
        Aspose.Slides.Charts.IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
        errBarY.IsVisible = true;
        errBarY.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Custom;

        // Set data source types for custom error bar values
        Aspose.Slides.Charts.IChartDataPointCollection points = series.DataPoints;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;

        // Assign custom error bar values for each data point
        for (int i = 0; i < points.Count; i++)
        {
            points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
            points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
            points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
            points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
        }

        // Save the presentation
        pres.Save("CustomErrorBars.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}