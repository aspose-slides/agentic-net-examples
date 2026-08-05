// -----------------------------------------------------------------------------
// Example: Set pie chart labels outside end using C#
//
// Description:
// Demonstrates how to set pie chart data labels to the OutsideEnd position using
// C# and Aspose.Slides for .NET. The example creates a new presentation, adds a
// pie chart, populates it with categories and a data series, configures the
// label position, and saves the result as a PPTX file. This pattern can be used
// to automate chart formatting tasks in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Pie Chart, Labels, OutsideEnd,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting pie chart labels to OutsideEnd.
// - Build C# utilities for PowerPoint chart formatting.
// - Generate or modify PPTX files with custom chart label positions.
// - Validate chart label configurations before publishing presentations.
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
        Presentation pres = new Presentation();

        // Get the first slide
        ISlide slide = pres.Slides[0];

        // Add a pie chart to the slide
        IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

        // Clear any default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Get the chart data workbook
        IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

        // Add a series
        IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

        // Add data points for the series
        series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 1, 1, 30));
        series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 2, 1, 40));
        series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 3, 1, 30));

        // Set data label position to OutsideEnd for each slice
        series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;

        // Save the presentation
        try
        {
            pres.Save("PieChartDataLabelPosition.pptx", SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Handle format not supported exception
            // Format not supported
        }
    }
}
