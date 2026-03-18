using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace CustomChartFormatting
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // ==========================
                // Add and format Treemap chart
                // ==========================
                IChart treemapChart = slide.Shapes.AddChart(ChartType.Treemap, 50f, 50f, 400f, 300f);
                IChartDataWorkbook workbook = treemapChart.ChartData.ChartDataWorkbook;

                // Clear default series and categories
                treemapChart.ChartData.Series.Clear();
                treemapChart.ChartData.Categories.Clear();

                // Add a series
                IChartSeries treemapSeries = treemapChart.ChartData.Series.Add(
                    workbook.GetCell(0, 0, 1, "Series 1"), treemapChart.Type);

                // Add categories
                treemapChart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category A"));
                treemapChart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category B"));
                treemapChart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category C"));

                // Add data points with size values
                IChartDataPoint treemapPoint1 = treemapSeries.DataPoints.AddDataPointForTreemapSeries(
                    workbook.GetCell(0, 1, 1, 30));
                IChartDataPoint treemapPoint2 = treemapSeries.DataPoints.AddDataPointForTreemapSeries(
                    workbook.GetCell(0, 2, 1, 50));
                IChartDataPoint treemapPoint3 = treemapSeries.DataPoints.AddDataPointForTreemapSeries(
                    workbook.GetCell(0, 3, 1, 20));

                // Custom formatting for each data point
                treemapPoint1.Format.Fill.SolidFillColor.Color = Color.Red;
                treemapPoint2.Format.Fill.SolidFillColor.Color = Color.Green;
                treemapPoint3.Format.Fill.SolidFillColor.Color = Color.Blue;

                // ==========================
                // Add and format Sunburst chart
                // ==========================
                IChart sunburstChart = slide.Shapes.AddChart(ChartType.Sunburst, 500f, 50f, 400f, 300f);
                IChartDataWorkbook workbook2 = sunburstChart.ChartData.ChartDataWorkbook;

                // Clear default series and categories
                sunburstChart.ChartData.Series.Clear();
                sunburstChart.ChartData.Categories.Clear();

                // Add a series
                IChartSeries sunburstSeries = sunburstChart.ChartData.Series.Add(
                    workbook2.GetCell(0, 0, 1, "Series 1"), sunburstChart.Type);

                // Add categories (hierarchical levels can be represented by multiple categories)
                sunburstChart.ChartData.Categories.Add(workbook2.GetCell(0, 1, 0, "Root"));
                sunburstChart.ChartData.Categories.Add(workbook2.GetCell(0, 2, 0, "Child 1"));
                sunburstChart.ChartData.Categories.Add(workbook2.GetCell(0, 3, 0, "Child 2"));

                // Add data points with size values
                IChartDataPoint sunburstPoint1 = sunburstSeries.DataPoints.AddDataPointForSunburstSeries(
                    workbook2.GetCell(0, 1, 1, 40));
                IChartDataPoint sunburstPoint2 = sunburstSeries.DataPoints.AddDataPointForSunburstSeries(
                    workbook2.GetCell(0, 2, 1, 60));
                IChartDataPoint sunburstPoint3 = sunburstSeries.DataPoints.AddDataPointForSunburstSeries(
                    workbook2.GetCell(0, 3, 1, 20));

                // Custom formatting for each data point
                sunburstPoint1.Format.Fill.SolidFillColor.Color = Color.Orange;
                sunburstPoint2.Format.Fill.SolidFillColor.Color = Color.Purple;
                sunburstPoint3.Format.Fill.SolidFillColor.Color = Color.Yellow;

                // Save the presentation
                presentation.Save("CustomTreemapSunburst.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}