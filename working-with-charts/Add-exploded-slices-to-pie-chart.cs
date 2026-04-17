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
            // Data values and threshold for explosion
            double[] values = new double[] { 30, 70, 15, 85, 40 };
            double threshold = 50;

            // Create a new presentation
            Presentation pres = new Presentation();
            ISlide slide = pres.Slides[0];

            // Add a pie chart
            IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 400);

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 4, 0, "Category 4"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 5, 0, "Category 5"));

            // Add a series
            IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

            // Add data points and explode slices exceeding the threshold
            for (int i = 0; i < values.Length; i++)
            {
                IChartDataPoint point = series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, i + 1, 1, values[i]));
                if (values[i] > threshold)
                {
                    point.Explosion = 20; // explode 20% of the pie diameter
                }
            }

            // Save the presentation
            string outPath = "ExplodedPieChart.pptx";
            pres.Save(outPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle errors (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}