using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace BoxWhiskerChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a Box-and-Whisker chart without sample data
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.BoxAndWhisker,
                    50f, 50f, 500f, 400f, false);

                // Remove default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Get the chart data workbook
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Add a series
                chart.ChartData.Series.Add(
                    workbook.GetCell(0, 0, 1, "Series 1"),
                    chart.Type);

                // Add categories (labels for each box)
                workbook.GetCell(0, 1, 0, "Category A");
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category A"));
                workbook.GetCell(0, 2, 0, "Category B");
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category B"));
                workbook.GetCell(0, 3, 0, "Category C");
                chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category C"));

                // Populate series with Box-and-Whisker data points
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

                // Data point for Category A
                series.DataPoints.AddDataPointForBoxAndWhiskerSeries(
                    workbook.GetCell(0, 1, 1, new double[] { 10, 12, 14, 16, 18 }));

                // Data point for Category B
                series.DataPoints.AddDataPointForBoxAndWhiskerSeries(
                    workbook.GetCell(0, 2, 1, new double[] { 20, 22, 24, 26, 28 }));

                // Data point for Category C
                series.DataPoints.AddDataPointForBoxAndWhiskerSeries(
                    workbook.GetCell(0, 3, 1, new double[] { 30, 32, 34, 36, 38 }));

                // Save the presentation
                String outputPath = Path.Combine(Directory.GetCurrentDirectory(), "BoxWhiskerChart_out.pptx");
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}