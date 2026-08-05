// -----------------------------------------------------------------------------
// Example: Set category axis to date using C#
//
// Description:
// Demonstrates how to set the category axis of a chart to a date axis using
// Aspose.Slides for .NET. The example creates a new presentation, adds an Area
// chart, populates it with date categories and a line series, configures the
// horizontal axis as a date axis with a custom number format, and saves the
// result as a PPTX file.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, Chart, Category Axis, Date Axis, 
// Presentation Automation, Office Automation, .NET
//
// Use Cases:
// - Automate creation of charts with date-based category axes.
// - Build .NET tools for generating or modifying PowerPoint presentations.
// - Produce reports that require time-series data visualisation.
// - Validate chart configurations programmatically before publishing.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = "DateAxisChart.pptx";

        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add an Area chart
            Aspose.Slides.Charts.IChart chart = pres.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Area, 50f, 50f, 600f, 400f);

            // Get the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

            // Clear default data
            wb.Clear(0);
            chart.ChartData.Categories.Clear();
            chart.ChartData.Series.Clear();

            // Add date categories
            chart.ChartData.Categories.Add(wb.GetCell(0, "A2", DateTime.Parse("2023-01-01").ToOADate()));
            chart.ChartData.Categories.Add(wb.GetCell(0, "A3", DateTime.Parse("2023-02-01").ToOADate()));
            chart.ChartData.Categories.Add(wb.GetCell(0, "A4", DateTime.Parse("2023-03-01").ToOADate()));
            chart.ChartData.Categories.Add(wb.GetCell(0, "A5", DateTime.Parse("2023-04-01").ToOADate()));

            // Add a line series with values
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(Aspose.Slides.Charts.ChartType.Line);
            series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B2", 10));
            series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B3", 20));
            series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B4", 15));
            series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B5", 25));

            // Set the horizontal axis to date type and define number format
            chart.Axes.HorizontalAxis.CategoryAxisType = Aspose.Slides.Charts.CategoryAxisType.Date;
            chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
            chart.Axes.HorizontalAxis.NumberFormat = "dd-MMM";

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
