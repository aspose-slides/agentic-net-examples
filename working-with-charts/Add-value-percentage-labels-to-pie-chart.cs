// -----------------------------------------------------------------------------
// Example: Add value percentage labels to pie chart using C#
//
// Description:
// Demonstrates how to add both value and percentage data labels to a pie chart 
// using C# and Aspose.Slides for .NET. The example creates a new presentation, 
// inserts a pie chart, populates it with categories and data points, configures 
// the series to display value and percentage on each slice, and saves the 
// result as a PPTX file. This pattern can be used to automate chart labeling 
// tasks in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Value, Percentage, Labels, 
// Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding value and percentage labels to pie charts.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with customized chart data labels.
// - Validate chart presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace PieChartDataLabels
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a pie chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50f, 50f, 500f, 400f);

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category A"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category B"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category C"));

            // Add a new series
            IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

            // Add data points for the pie series
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 1, 1, 30));
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 2, 1, 45));
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 3, 1, 25));

            // Display both value and percentage on each data label
            series.Labels.DefaultDataLabelFormat.ShowValue = true;
            series.Labels.DefaultDataLabelFormat.ShowPercentage = true;

            // Save the presentation
            try
            {
                presentation.Save("PieChartWithDataLabels.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle format not supported or other exceptions
                // Format not supported
            }
        }
    }
}
