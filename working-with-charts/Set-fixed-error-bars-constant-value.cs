// -----------------------------------------------------------------------------
// Example: Set fixed error bars constant value using C#
//
// Description:
// Demonstrates how to set a fixed constant value for error bars in a chart 
// using C# and Aspose.Slides for .NET. The example creates a presentation, 
// adds a clustered column chart, populates data, configures error bars with a 
// constant length, and saves the file. This pattern helps automate chart 
// formatting tasks in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Fixed Error Bars, Constant Value, 
// Chart, Error Bars, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting fixed error bar values in charts.
// - Build .NET tools for PowerPoint chart customization.
// - Generate or modify PPTX files with specific error bar configurations.
// - Validate chart data visualizations before publishing.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace FixedErrorBarsExample
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

                // Get the chart data workbook
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

                // Populate series data
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 40));
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));

                // Configure fixed value error bars (0.2) for the series
                IErrorBarsFormat errorBars = series.ErrorBarsYFormat;
                if (errorBars != null)
                {
                    errorBars.IsVisible = true;
                    errorBars.ValueType = ErrorBarValueType.Fixed;          // Use Fixed value type
                    errorBars.Type = ErrorBarType.Both;                    // Show both positive and negative error bars
                    errorBars.Value = 0.2f;                                // Constant error bar length
                }

                // Save the presentation
                try
                {
                    presentation.Save("FixedErrorBars.pptx", SaveFormat.Pptx);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
                catch (Exception)
                {
                    // Handle other exceptions (e.g., file I/O)
                }
            }
        }
    }
}
