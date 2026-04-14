using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a bubble chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Bubble, 50, 50, 500, 400, true);

        // Get the first series of the chart
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Get error bars formats for X and Y directions
        Aspose.Slides.Charts.IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
        Aspose.Slides.Charts.IErrorBarsFormat errBarY = series.ErrorBarsYFormat;

        // Make error bars visible and set them to use custom values
        errBarX.IsVisible = true;
        errBarY.IsVisible = true;
        errBarX.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Custom;
        errBarY.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Custom;

        // Set the data source type for custom error values to literal doubles
        Aspose.Slides.Charts.IChartDataPointCollection points = series.DataPoints;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;

        // Custom error bar offset arrays (negative and positive for X and Y)
        double[] xMinusOffsets = new double[] { 0.5, 0.6, 0.7 };
        double[] xPlusOffsets = new double[] { 0.8, 0.9, 1.0 };
        double[] yMinusOffsets = new double[] { 0.2, 0.3, 0.4 };
        double[] yPlusOffsets = new double[] { 0.5, 0.6, 0.7 };

        // Assign custom error values to each data point (use the minimum count to avoid out of range)
        int pointCount = points.Count;
        int length = Math.Min(pointCount, Math.Min(xMinusOffsets.Length,
                     Math.Min(xPlusOffsets.Length, Math.Min(yMinusOffsets.Length, yPlusOffsets.Length))));

        for (int i = 0; i < length; i++)
        {
            points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = xMinusOffsets[i];
            points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = xPlusOffsets[i];
            points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = yMinusOffsets[i];
            points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = yPlusOffsets[i];
        }

        // Save the presentation
        string outputPath = "CustomErrorBars.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}