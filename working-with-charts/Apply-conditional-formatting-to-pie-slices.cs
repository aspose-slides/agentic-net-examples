using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ConditionalPieChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a pie chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

            // Set chart title
            chart.ChartTitle.AddTextFrameForOverriding("Sales Distribution");
            chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
            chart.ChartTitle.Height = 20;
            chart.HasTitle = true;

            // Enable automatic varied colors for each slice
            chart.ChartData.Series[0].ParentSeriesGroup.IsColorVaried = true;

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Product A"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Product B"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Product C"));

            // Add a series
            IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Sales"), chart.Type);

            // Add data points with values
            IChartDataPoint point1 = series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 1, 1, 30));
            IChartDataPoint point2 = series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 2, 1, 70));
            IChartDataPoint point3 = series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 3, 1, 45));

            // Conditional formatting: set slice colors based on value thresholds
            // Threshold: value > 50 => Red, otherwise Green
            IChartDataPoint[] dataPoints = new IChartDataPoint[] { point1, point2, point3 };
            double[] values = new double[] { 30, 70, 45 };

            for (int i = 0; i < dataPoints.Length; i++)
            {
                IChartDataPoint dp = dataPoints[i];
                double val = values[i];

                // Set fill type to solid
                dp.Format.Fill.FillType = FillType.Solid;

                // Apply color based on threshold
                if (val > 50)
                {
                    dp.Format.Fill.SolidFillColor.Color = Color.Red;
                }
                else
                {
                    dp.Format.Fill.SolidFillColor.Color = Color.Green;
                }
            }

            // Save the presentation
            presentation.Save("ConditionalPieChart.pptx", SaveFormat.Pptx);
        }
    }
}