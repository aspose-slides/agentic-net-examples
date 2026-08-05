// -----------------------------------------------------------------------------
// Example: Add polar chart with custom radii using C#
//
// Description:
// Demonstrates how to add a polar chart with custom radii using C# and 
// Aspose.Slides for .NET. The example creates a new presentation, inserts a 
// polar chart, customizes its radii, and saves the result as a PPTX file. 
// Developers can use this pattern to automate PPTX workflows, validate results, 
// or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Polar Chart, Custom Radii, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding polar charts with specific radius settings.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        using (Presentation presentation = new Presentation())
        {
            // Add a blank slide
            ISlide slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

            // Add a polar chart
            IChart chart = slide.Shapes.AddChart(ChartType.Polar, 50, 50, 500, 400);

            // Set chart title
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("Polar Chart with Custom Radii");

            // Populate chart with sample data
            IChartData chartData = chart.ChartData;
            chartData.Series.Clear();
            chartData.Categories.Clear();

            // Add categories (e.g., angles)
            chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A1", "0°"));
            chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A2", "45°"));
            chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A3", "90°"));
            chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A4", "135°"));
            chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A5", "180°"));
            chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A6", "225°"));
            chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A7", "270°"));
            chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A8", "315°"));

            // Add a series with sample values
            IChartSeries series = chartData.Series.Add(ChartType.Polar);
            series.Name = "Sample Series";
            series.DataPoints.AddDataPointForPolarSeries(chartData.ChartDataWorkbook.GetCell(0, "B1", 10));
            series.DataPoints.AddDataPointForPolarSeries(chartData.ChartDataWorkbook.GetCell(0, "B2", 20));
            series.DataPoints.AddDataPointForPolarSeries(chartData.ChartDataWorkbook.GetCell(0, "B3", 30));
            series.DataPoints.AddDataPointForPolarSeries(chartData.ChartDataWorkbook.GetCell(0, "B4", 25));
            series.DataPoints.AddDataPointForPolarSeries(chartData.ChartDataWorkbook.GetCell(0, "B5", 15));
            series.DataPoints.AddDataPointForPolarSeries(chartData.ChartDataWorkbook.GetCell(0, "B6", 5));
            series.DataPoints.AddDataPointForPolarSeries(chartData.ChartDataWorkbook.GetCell(0, "B7", 12));
            series.DataPoints.AddDataPointForPolarSeries(chartData.ChartDataWorkbook.GetCell(0, "B8", 18));

            // Customize radii (example: set minimum and maximum radius)
            // Note: The actual API for setting custom radii may vary based on Aspose.Slides version.
            // The following demonstrates the typical approach using the Chart's Axes.
            IChartAxis radialAxis = chart.Axes[AxisType.Value];
            radialAxis.IsAutomaticMinValue = false;
            radialAxis.IsAutomaticMaxValue = false;
            radialAxis.MinValue = 0;   // Minimum radius
            radialAxis.MaxValue = 40;  // Maximum radius

            // Save the presentation
            presentation.Save("PolarChartCustomRadii.pptx", SaveFormat.Pptx);
        }
    }
}
