// -----------------------------------------------------------------------------
// Example: Add custom callout arrow to pie slice using C#
//
// Description:
// Demonstrates how to add a custom callout arrow to a specific pie slice using
// C# and Aspose.Slides for .NET. The example creates a new presentation, adds a
// pie chart, configures data, enables a data callout for the second slice, and
// optionally explodes that slice to highlight it. The resulting PPTX file
// contains a pie chart with a callout arrow pointing to the chosen slice.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Custom, Callout, Arrow, Pie Slice,
// Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding callout arrows to pie chart slices.
// - Build C# tools for enhancing PowerPoint chart visualizations.
// - Generate or modify PPTX files with custom chart annotations in .NET
//   applications.
// - Validate chart presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a pie chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50f, 50f, 400f, 400f);

            // Clear default data
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category A"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category B"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category C"));

            // Add series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

            // Add data points
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 1, 1, 30));
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 2, 1, 50));
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 3, 1, 20));

            // Enable callout for the second slice (index 1)
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

            // Optionally explode the second slice to emphasize it
            series.DataPoints[1].Explosion = 20;

            // Save the presentation
            presentation.Save("CustomCalloutPieChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.IO.FileNotFoundException ex)
        {
            // Handle missing file if any input files were used
            Console.WriteLine("File not found: " + ex.Message);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            // format not supported
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
