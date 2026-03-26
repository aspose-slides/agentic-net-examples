using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace DoughnutChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add an exploded doughnut chart (initialize without sample data)
                IChart chart = slide.Shapes.AddChart(
                    ChartType.ExplodedDoughnut,
                    0f, 0f, 500f, 400f,
                    false);

                // Access the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Clear any default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add a series name cell
                IChartDataCell seriesNameCell = workbook.GetCell(0, "A1", "Series 1");
                // Add the series to the chart
                IChartSeries series = chart.ChartData.Series.Add(seriesNameCell, ChartType.ExplodedDoughnut);

                // Add category cells
                IChartDataCell cat1 = workbook.GetCell(0, "B1", "Category A");
                IChartDataCell cat2 = workbook.GetCell(0, "C1", "Category B");
                IChartDataCell cat3 = workbook.GetCell(0, "D1", "Category C");
                chart.ChartData.Categories.Add(cat1);
                chart.ChartData.Categories.Add(cat2);
                chart.ChartData.Categories.Add(cat3);

                // Configure the data points to accept double literals
                series.DataPoints.DataSourceTypeForValues = DataSourceType.DoubleLiterals;

                // Add data points for the doughnut series
                series.DataPoints.AddDataPointForDoughnutSeries(40.0);
                series.DataPoints.AddDataPointForDoughnutSeries(30.0);
                series.DataPoints.AddDataPointForDoughnutSeries(30.0);

                // Set the doughnut hole size (percentage of plot area, 0-90)
                series.ParentSeriesGroup.DoughnutHoleSize = 50; // 50%

                // Optional: Add a chart title
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Sales Distribution");
                chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
                chart.ChartTitle.Height = 20;

                // Save the presentation
                string outPath = "DoughnutChart.pptx";
                pres.Save(outPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to " + Path.GetFullPath(outPath));
            }
        }
    }
}