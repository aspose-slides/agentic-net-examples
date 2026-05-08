using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

namespace BatchDoughnutCharts
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sample input data for each presentation
            double[][] dataSets = new double[][]
            {
                new double[] { 30, 20, 50 },
                new double[] { 10, 40, 50 },
                new double[] { 25, 25, 50 }
            };

            for (int presentationIndex = 0; presentationIndex < dataSets.Length; presentationIndex++)
            {
                try
                {
                    // Create a new presentation
                    Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                    // Get the first slide
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    // Add a doughnut chart
                    Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                        Aspose.Slides.Charts.ChartType.Doughnut,
                        50f, 50f, 500f, 400f);

                    // Remove default series and categories
                    chart.ChartData.Series.Clear();
                    chart.ChartData.Categories.Clear();

                    // Get the chart data workbook
                    Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                    int defaultWorksheetIndex = 0;

                    // Add categories
                    chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
                    chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
                    chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

                    // Add a series
                    Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                        workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
                        chart.Type);

                    // Populate series with doughnut data points
                    double[] data = dataSets[presentationIndex];
                    for (int i = 0; i < data.Length; i++)
                    {
                        series.DataPoints.AddDataPointForDoughnutSeries(data[i]);
                    }

                    // Set a unique solid fill color for the series
                    series.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                    series.Format.Fill.SolidFillColor.Color = Color.FromArgb(
                        (presentationIndex * 70) % 256,
                        (presentationIndex * 130) % 256,
                        (presentationIndex * 200) % 256);

                    // Adjust the doughnut hole size
                    series.ParentSeriesGroup.DoughnutHoleSize = 50; // 50%

                    // Save the presentation
                    string outputPath = $"DoughnutChart_{presentationIndex}.pptx";
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                    // Dispose the presentation
                    presentation.Dispose();
                }
                catch (Exception ex)
                {
                    // Handle any unexpected errors (e.g., unsupported format)
                    Console.WriteLine($"Error creating presentation {presentationIndex}: {ex.Message}");
                }
            }
        }
    }
}