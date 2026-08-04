// -----------------------------------------------------------------------------
// Example: Set error bar line style to dashdot using C#
//
// Description:
// Demonstrates how to set the Y error bar line style to DashDot for a line
// chart using C# and Aspose.Slides for .NET. The example creates a presentation,
// adds a line chart with sample data, enables Y‑direction error bars, applies a
// DashDot line style, and saves the result as a PPTX file. This pattern can be
// used to customize error bar appearance in automated PowerPoint workflows.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Line Chart, Error Bars,
// Line Style, DashDot, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting error bar line style to DashDot in PowerPoint charts.
// - Build C# utilities for customizing chart appearance in presentations.
// - Generate or modify PPTX files with specific error bar styling in .NET apps.
// - Validate chart formatting before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetErrorBarLineStyle
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a line chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.Line, 0, 0, 500, 400);

            // Ensure the chart has at least one series
            if (chart.ChartData.Series.Count == 0)
            {
                // Add a sample series if none exist
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), ChartType.Line);
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
                chart.ChartData.Series[0].DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 1, 10));
                chart.ChartData.Series[0].DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 1, 20));
            }

            // Get the first series
            IChartSeries series = chart.ChartData.Series[0];

            // Make error bars visible (Y direction) and set dash style to DashDot
            if (series.ErrorBarsYFormat != null)
            {
                series.ErrorBarsYFormat.IsVisible = true;
                series.ErrorBarsYFormat.Format.Line.DashStyle = Aspose.Slides.LineDashStyle.DashDot;
            }

            // Save the presentation
            pres.Save("SetErrorBarLineStyle.pptx", SaveFormat.Pptx);
        }
    }
}
