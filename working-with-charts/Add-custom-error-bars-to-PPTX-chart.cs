using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a bubble chart with sample data
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Bubble, 50f, 50f, 600f, 400f, true);

        // Get the first series of the chart
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Enable custom error bars for X and Y directions
        Aspose.Slides.Charts.IErrorBarsFormat errorBarsX = series.ErrorBarsXFormat;
        errorBarsX.IsVisible = true;
        errorBarsX.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Custom;

        Aspose.Slides.Charts.IErrorBarsFormat errorBarsY = series.ErrorBarsYFormat;
        errorBarsY.IsVisible = true;
        errorBarsY.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Custom;

        // Set the data source type for custom error values to literal doubles
        Aspose.Slides.Charts.IChartDataPointCollection points = series.DataPoints;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;

        // Assign custom error values for each data point
        for (int i = 0; i < points.Count; i++)
        {
            points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 0.5;
            points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 0.5;
            points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 0.5;
            points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 0.5;
        }

        // Save the presentation
        presentation.Save("CustomErrorBars.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}