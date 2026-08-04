// -----------------------------------------------------------------------------
// Example: Add secondary plot to bar of pie chart with threshold using C#
//
// Description:
// Demonstrates how to add a secondary plot (split) to a Bar of Pie chart using
// Aspose.Slides for .NET. The example creates a new presentation, inserts a
// Bar of Pie chart, defines categories and a data series, configures the
// secondary pie plot with a split threshold, and saves the result as a PPTX
// file. This pattern can be used to automate chart creation and customization
// in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Bar of Pie, Secondary Plot,
// Threshold, Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate creation of Bar of Pie charts with secondary plot thresholds.
// - Build C# tools for advanced chart customization in PowerPoint.
// - Generate or modify PPTX files programmatically in .NET applications.
// - Validate chart configurations before publishing presentations.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "BarOfPieChart_out.pptx";
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a Bar of Pie chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.BarOfPie, 50, 50, 500, 400);

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

            // Add a series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);

            // Populate series data points
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 30));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 50));

            // Enable secondary plot and adjust split options
            series.Labels.DefaultDataLabelFormat.ShowValue = true;
            series.ParentSeriesGroup.SecondPieSize = 150; // 150%
            series.ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
            series.ParentSeriesGroup.PieSplitPosition = 30.0; // split threshold

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.IO.IOException ioEx)
        {
            Console.WriteLine("IO error: " + ioEx.Message);
        }
        catch (System.NotSupportedException nsEx)
        {
            // format not supported
            Console.WriteLine("Format not supported: " + nsEx.Message);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
