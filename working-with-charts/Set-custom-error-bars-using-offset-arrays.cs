// -----------------------------------------------------------------------------
// Example: Set custom error bars using offset arrays using C#
//
// Description:
// Demonstrates how to create a bubble chart and set custom error bars using
// offset arrays for both X and Y directions with Aspose.Slides for .NET.
// The example shows the required presentation-processing steps for PowerPoint
// files and produces a PPTX file with custom error bars in a standalone console
// application. Developers can use this pattern to automate chart error bar
// customization, validate results, or integrate presentation logic into .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Custom Error Bars, Offset Arrays,
// Bubble Chart, Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting custom error bars using offset arrays in charts.
// - Build C# tools for PowerPoint chart manipulation.
// - Generate or transform PPTX files with customized error bars in .NET apps.
// - Validate chart error bar configurations before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
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

        // Define custom error offsets for each data point
        double[] xMinusOffsets = new double[] { 0.5, 0.3, 0.4 };
        double[] xPlusOffsets = new double[] { 0.6, 0.2, 0.5 };
        double[] yMinusOffsets = new double[] { 0.7, 0.1, 0.3 };
        double[] yPlusOffsets = new double[] { 0.8, 0.4, 0.6 };

        // Apply custom error values to each data point (use the minimum count to avoid out-of-range)
        int pointCount = Math.Min(points.Count, xMinusOffsets.Length);
        for (int i = 0; i < pointCount; i++)
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
