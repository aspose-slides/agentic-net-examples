// -----------------------------------------------------------------------------
// Example: Add arrow callout to pie slice using C#
//
// Description:
// Demonstrates how to add a data label callout (arrow) to a pie chart slice 
// using C# and Aspose.Slides for .NET. The example creates a presentation, 
// inserts a pie chart, configures series data, explodes a slice, and enables 
// callout labels for the slice. This pattern can be used to automate PPTX 
// workflows, customize chart annotations, or integrate presentation logic into 
// .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Pie Chart, Callout, Data Labels, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding callout arrows to pie chart slices.
// - Build C# tools for PowerPoint chart customization.
// - Generate or transform PPTX files with annotated charts in .NET applications.
// - Validate chart presentation workflows before publishing or integration.
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
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a pie chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50, 50, 400, 400);

        // Set chart title
        chart.ChartTitle.AddTextFrameForOverriding("Sales Distribution");
        chart.HasTitle = true;

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Product A"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Product B"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Product C"));

        // Add a series
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

        // Add data points
        series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 1, 1, 30));
        series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 2, 1, 50));
        series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 3, 1, 20));

        // Explode the second slice (Product B)
        series.DataPoints[1].Explosion = 30;

        // Enable callout for data labels
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

        // Save the presentation
        pres.Save("CustomCalloutPieChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
