// -----------------------------------------------------------------------------
// Example: Apply logarithmic y axis to line chart using C#
//
// Description:
// Demonstrates how to create a line chart with exponential data and apply a
// logarithmic scale to the Y axis using Aspose.Slides for .NET. The example
// shows the required presentation-processing steps for PowerPoint files and
// produces a PPTX file in a standalone console application. Developers can
// use this pattern to automate PPTX workflows, validate results, or integrate
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Logarithmic Y Axis, Line Chart,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate applying a logarithmic Y axis to line charts in presentations.
// - Build C# tools for PowerPoint chart manipulation.
// - Generate or transform PPTX files with custom chart scaling in .NET
//   applications.
// - Validate chart rendering before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a line chart with sample size and position
            IChart chart = slide.Shapes.AddChart(ChartType.Line, 50f, 50f, 500f, 400f);

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Define categories (X axis values)
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "3"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 4, 0, "4"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 5, 0, "5"));

            // Add a series for exponential data
            IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "ExpSeries"), chart.Type);

            // Populate series with exponential values (e^x)
            series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 1, Math.Exp(1)));
            series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 1, Math.Exp(2)));
            series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 1, Math.Exp(3)));
            series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 1, Math.Exp(4)));
            series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 5, 1, Math.Exp(5)));

            // Apply logarithmic scale to the Y axis
            chart.Axes.VerticalAxis.IsLogarithmic = true;
            // Optional: set logarithmic base (default is 10)
            chart.Axes.VerticalAxis.LogBase = 10;

            // Save the presentation
            presentation.Save("LogarithmicLineChart.pptx", SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}
