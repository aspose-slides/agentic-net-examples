// -----------------------------------------------------------------------------
// Example: Add exploded slices to pie chart using C#
//
// Description:
// Demonstrates how to add exploded slices to a pie chart based on a value
// threshold using C# and Aspose.Slides for .NET. The example creates a new
// presentation, inserts a pie chart, populates it with data, and explodes
// slices whose values exceed the specified threshold. This pattern shows the
// required presentation‑processing steps for PowerPoint files and produces
// the requested output in a standalone console application. Developers can
// use this example to automate PPTX workflows, validate results, or integrate
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Pie Chart, Exploded Slices,
// Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding exploded slices to pie charts in presentations.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with customized chart visuals in .NET
//   applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Output file
        string outPath = "ExplodedPieChart.pptx";

        // Data values and categories
        double[] values = new double[] { 30, 70, 15, 85, 40 };
        string[] categories = new string[] { "A", "B", "C", "D", "E" };

        // Explosion settings
        int explosionPercent = 20; // distance as percentage of pie diameter
        double threshold = 50; // explode slices with value greater than this

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a pie chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50, 50, 500, 400);

        // Clear default data
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Workbook for chart data
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Add categories
        int i;
        for (i = 0; i < categories.Length; i++)
        {
            chart.ChartData.Categories.Add(workbook.GetCell(0, i + 1, 0, categories[i]));
        }

        // Add a series
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

        // Add data points and explode slices exceeding the threshold
        for (i = 0; i < values.Length; i++)
        {
            Aspose.Slides.Charts.IChartDataPoint point = series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, i + 1, 1, values[i]));
            if (values[i] > threshold)
            {
                point.Explosion = explosionPercent;
            }
        }

        // Save the presentation
        try
        {
            pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }

        // Clean up
        pres.Dispose();
    }
}
