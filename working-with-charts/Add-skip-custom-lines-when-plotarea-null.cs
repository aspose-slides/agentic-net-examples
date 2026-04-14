using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a bubble chart with sample data
        IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 500, 400, true);

        // Get the first series
        IChartSeries series = chart.ChartData.Series[0];

        // Get error bars formats for X and Y directions
        IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
        IErrorBarsFormat errBarY = series.ErrorBarsYFormat;

        // Make error bars visible
        errBarX.IsVisible = true;
        errBarY.IsVisible = true;

        // Set custom error bar value type
        errBarX.ValueType = ErrorBarValueType.Custom;
        errBarY.ValueType = ErrorBarValueType.Custom;

        // Get data points collection
        IChartDataPointCollection points = series.DataPoints;

        // Set data source types for custom error values
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

        // Add custom error values only if PlotArea is available
        if (chart.PlotArea != null)
        {
            for (int i = 0; i < points.Count; i++)
            {
                points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
                points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
                points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
                points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
            }
        }

        // Save the presentation
        presentation.Save("CustomErrorBars.pptx", SaveFormat.Pptx);
        presentation.Dispose();
    }
}