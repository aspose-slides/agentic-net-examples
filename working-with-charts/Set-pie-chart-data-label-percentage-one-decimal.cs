// -----------------------------------------------------------------------------
// Example: Set pie chart data label percentage one decimal using C#
//
// Description:
// Demonstrates how to set pie chart data label percentages to display with one
// decimal place using C# and Aspose.Slides for .NET. The example creates a new
// presentation, adds a pie chart, populates it with categories and data, configures
// the data labels to show percentages formatted as "0.0%", and saves the file.
// This pattern can be used to automate chart formatting in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Pie Chart, Data Labels,
// Percentage Formatting, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting pie chart data label percentages to one decimal.
// - Build C# utilities for PowerPoint chart customization.
// - Generate or modify PPTX files with specific chart label formats.
// - Validate chart label formatting in presentation workflows.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Add a pie chart
        IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 400);

        // Access the chart data workbook
        IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

        // Add a series
        IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

        // Add data points
        series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 1, 1, 30));
        series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 2, 1, 50));
        series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 3, 1, 20));

        // Configure data labels to show percentages with one decimal place
        series.Labels.DefaultDataLabelFormat.ShowPercentage = true;
        series.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
        series.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";

        // Save the presentation
        presentation.Save("PieChartWithPercentage.pptx", SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}
