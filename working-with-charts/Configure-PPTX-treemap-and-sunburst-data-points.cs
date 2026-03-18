using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Access the first slide
                ISlide slide = pres.Slides[0];

                // -------------------- Treemap Chart --------------------
                // Add a treemap chart
                IChart treemapChart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Treemap, 50, 50, 500, 400);

                // Get the chart data workbook
                IChartDataWorkbook treemapWb = treemapChart.ChartData.ChartDataWorkbook;

                // Clear default series and categories
                treemapChart.ChartData.Series.Clear();
                treemapChart.ChartData.Categories.Clear();

                // Add a series for the treemap chart
                IChartSeries treemapSeries = treemapChart.ChartData.Series.Add(treemapWb.GetCell(0, 0, 1, "Treemap Series"), treemapChart.Type);

                // Add data points (size values) to the series
                treemapSeries.DataPoints.AddDataPointForTreemapSeries(treemapWb.GetCell(0, 1, 1, 30));
                treemapSeries.DataPoints.AddDataPointForTreemapSeries(treemapWb.GetCell(0, 2, 1, 20));
                treemapSeries.DataPoints.AddDataPointForTreemapSeries(treemapWb.GetCell(0, 3, 1, 50));

                // -------------------- Sunburst Chart --------------------
                // Add a sunburst chart
                IChart sunburstChart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Sunburst, 50, 500, 500, 400);

                // Get the chart data workbook
                IChartDataWorkbook sunburstWb = sunburstChart.ChartData.ChartDataWorkbook;

                // Clear default series and categories
                sunburstChart.ChartData.Series.Clear();
                sunburstChart.ChartData.Categories.Clear();

                // Add a series for the sunburst chart
                IChartSeries sunburstSeries = sunburstChart.ChartData.Series.Add(sunburstWb.GetCell(0, 0, 1, "Sunburst Series"), sunburstChart.Type);

                // Add data points (size values) to the series
                sunburstSeries.DataPoints.AddDataPointForSunburstSeries(sunburstWb.GetCell(0, 1, 1, 40));
                sunburstSeries.DataPoints.AddDataPointForSunburstSeries(sunburstWb.GetCell(0, 2, 1, 25));
                sunburstSeries.DataPoints.AddDataPointForSunburstSeries(sunburstWb.GetCell(0, 3, 1, 35));

                // Save the presentation
                pres.Save("TreemapSunburstChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}