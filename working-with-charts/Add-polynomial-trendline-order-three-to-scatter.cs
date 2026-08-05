// -----------------------------------------------------------------------------
// Example: Add polynomial trendline order three to scatter using C#
//
// Description:
// Demonstrates how to add a polynomial trendline of order three to a scatter
// chart with smooth lines using Aspose.Slides for .NET. The example creates a
// new presentation, inserts a scatter chart, populates it with data, applies
// the trendline, and saves the result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Scatter Chart, Polynomial,
// Trendline, Order Three, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a third‑order polynomial trendline to scatter charts.
// - Build C# utilities for PowerPoint chart manipulation.
// - Generate or modify PPTX files with custom chart analytics.
// - Validate chart trendline functionality in .NET applications.
// -----------------------------------------------------------------------------
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

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a scatter chart with smooth lines
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ScatterWithSmoothLines, 0f, 0f, 400f, 400f);

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
        int defaultWorksheetIndex = 0;

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add two series to the chart
        chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
        chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

        // Populate the first series with data points
        Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series[0];
        series1.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 1.0), workbook.GetCell(defaultWorksheetIndex, 2, 2, 2.0));
        series1.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 2.0), workbook.GetCell(defaultWorksheetIndex, 3, 2, 3.5));

        // Add a polynomial trend line of order 3 to the first series
        Aspose.Slides.Charts.ITrendline trendline = series1.TrendLines.Add(Aspose.Slides.Charts.TrendlineType.Polynomial);
        trendline.Order = 3;

        // Save the presentation
        presentation.Save("ScatterChartWithTrendline.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
