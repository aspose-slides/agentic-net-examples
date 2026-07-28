// -----------------------------------------------------------------------------
// Example: Insert chart bind data series set type using C#
//
// Description:
// Demonstrates how to insert a chart, bind data series, and set the chart type 
// using C# and Aspose.Slides for .NET. The example creates a new presentation, 
// adds a clustered column chart, clears default data, defines series and 
// categories, populates data points, and saves the file as a PPTX. This pattern 
// can be used to automate chart creation and data binding in PowerPoint 
// presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Insert, Chart, Bind, Data Series, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate insertion of charts with bound data series in PPTX files.
// - Build C# tools for generating or updating PowerPoint presentations with 
//   custom chart data.
// - Integrate chart creation into .NET applications for reporting or analytics.
// - Validate chart data binding workflows before publishing.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        // Add a chart of type ClusteredColumn at position (0,0) with size 500x500
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 0f, 0f, 500f, 500f);
        // Bind data series to the chart
        int defaultWorksheetIndex = 0;
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();
        // Add series
        Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
        Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);
        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));
        // Populate series data
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 20));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 30));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 10));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 60));
        // Save the presentation
        presentation.Save("ChartExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
