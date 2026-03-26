using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace CustomErrorBarsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            var presentation = new Presentation();

            // Add a bubble chart to the first slide with sample data
            var chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50f, 50f, 600f, 400f, true);

            // Get the first series of the chart
            var series = chart.ChartData.Series[0];

            // Configure X and Y error bars to be visible and use custom values
            var errBarX = series.ErrorBarsXFormat;
            var errBarY = series.ErrorBarsYFormat;
            errBarX.IsVisible = true;
            errBarY.IsVisible = true;
            errBarX.ValueType = ErrorBarValueType.Custom;
            errBarY.ValueType = ErrorBarValueType.Custom;

            // Set the data source type for custom error values to literals
            var points = series.DataPoints;
            points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
            points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
            points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
            points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

            // Assign custom error values for each data point
            for (int i = 0; i < points.Count; i++)
            {
                points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
                points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
                points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
                points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
            }

            // Save the presentation
            string outputPath = "CustomErrorBars.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}