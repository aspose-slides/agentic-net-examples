// -----------------------------------------------------------------------------
// Example: Set trendline forward zero backward three using C#
//
// Description:
// Demonstrates how to add a scatter chart, populate it with data, and set a
// linear trendline with forward length zero and backward length three using
// Aspose.Slides for .NET. The example creates a presentation, configures the
// chart, applies the trendline settings, and saves the result as a PPTX file.
// This pattern helps developers automate chart trendline adjustments in
// PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Scatter Chart, Trendline,
// Forward Zero, Backward Three, Chart Data, Presentation Automation
//
// Use Cases:
// - Automate setting trendline forward and backward lengths in charts.
// - Build C# utilities for PowerPoint chart manipulation.
// - Generate or modify PPTX files with customized trendlines.
// - Validate chart configurations programmatically.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Presentation presentation = new Presentation();
            ISlide slide = presentation.Slides[0];
            IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 500, 500);
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Clear default data
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add series
            chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
            chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

            // Add categories (optional for scatter)
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));

            // Populate first series with data points
            IChartSeries series0 = chart.ChartData.Series[0];
            series0.DataPoints.AddDataPointForScatterSeries(1.0, 2.0);
            series0.DataPoints.AddDataPointForScatterSeries(2.0, 3.5);

            // Add linear trendline and set forward/backward lengths
            ITrendline trendline = series0.TrendLines.Add(TrendlineType.Linear);
            trendline.Forward = 0;
            trendline.Backward = 3;

            // Save presentation
            string outputPath = "ScatterTrendline.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
