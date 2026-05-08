using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace EnableAutomaticPieChartLabelPositioning
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a pie chart (float literals required)
            IChart chart = slide.Shapes.AddChart(ChartType.Pie, 0f, 0f, 500f, 400f);

            // Optional: set chart title
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("Sales Distribution");
            chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;

            // Remove the default sample series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Product A"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Product B"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Product C"));

            // Add a series
            IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

            // Add data points using workbook cells (avoids DataSourceType mismatch)
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 1, 1, 30));
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 2, 1, 45));
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 3, 1, 25));

            // Enable automatic varied slice colors
            series.ParentSeriesGroup.IsColorVaried = true;

            // Enable automatic data label positioning (BestFit) to avoid overlapping
            series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.BestFit;

            // Show values on data labels
            series.Labels.DefaultDataLabelFormat.ShowValue = true;

            // Save the presentation (handle unsupported format)
            try
            {
                presentation.Save("AutomaticPieChart.pptx", SaveFormat.Pptx);
            }
            catch (ArgumentException)
            {
                // Format not supported
            }
        }
    }
}