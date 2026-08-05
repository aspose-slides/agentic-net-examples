// -----------------------------------------------------------------------------
// Example: Add secondary plot pie of pie radius using C#
//
// Description:
// Demonstrates how to create a Pie of Pie chart with a customized secondary
// plot (inner pie) radius using C# and Aspose.Slides for .NET. The example
// shows the required steps to build a presentation, add a Pie of Pie chart,
// configure its data, adjust the secondary plot size and split criteria, and
// save the result as a PPTX file. This pattern can be used to automate chart
// creation and styling in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Pie of Pie, Secondary Plot,
// Radius, Chart Customization, Presentation Processing, Office Automation
//
// Use Cases:
// - Generate Pie of Pie charts with a custom secondary plot radius.
// - Build C# tools for automated PowerPoint chart creation and styling.
// - Integrate advanced chart configurations into .NET applications.
// - Produce or modify PPTX files with specific chart visualizations.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddSecondaryPlotPieOfPie
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "PieOfPieChart.pptx";

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a Pie of Pie chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.PieOfPie,
                    50f, 50f, 500f, 400f);

                // Get the chart data workbook
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(0, 0, 1, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 0, 2, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 0, 3, "Category 3"));

                // Add a series
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                    workbook.GetCell(0, 0, 0, "Series 1"),
                    Aspose.Slides.Charts.ChartType.PieOfPie);

                // Configure the series to accept double literals
                series.DataPoints.DataSourceTypeForValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;

                // Populate series with data points
                series.DataPoints.AddDataPointForPieSeries(40.0);
                series.DataPoints.AddDataPointForPieSeries(30.0);
                series.DataPoints.AddDataPointForPieSeries(30.0);

                // Show values on data labels
                series.Labels.DefaultDataLabelFormat.ShowValue = true;

                // Customize the secondary plot (second pie)
                series.ParentSeriesGroup.SecondPieSize = 150; // Size as percentage of the first pie
                series.ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
                series.ParentSeriesGroup.PieSplitPosition = 5.0; // Split points with less than 5% into the second pie

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (ArgumentException ex) when (ex.Message.Contains("DataSourceTypeForValues"))
            {
                // Handle the specific data source type error
                Console.WriteLine("Error configuring data source type for chart values: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Comment: format not supported
            }
        }
    }
}
