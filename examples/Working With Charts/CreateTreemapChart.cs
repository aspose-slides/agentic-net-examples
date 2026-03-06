using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace TreemapChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a treemap chart without sample data
                IChart chart = slide.Shapes.AddChart(ChartType.Treemap, 0, 0, 500, 500, false);

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Get the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                int defaultWorksheetIndex = 0;

                // Add series
                IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
                IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

                // Populate data points for Series 1
                series1.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 30));
                series1.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
                series1.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 50));

                // Populate data points for Series 2
                series2.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 40));
                series2.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 60));
                series2.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 10));

                // Set chart title
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Treemap Chart");

                // Save the presentation
                pres.Save("TreemapChart_out.pptx", SaveFormat.Pptx);
            }
        }
    }
}