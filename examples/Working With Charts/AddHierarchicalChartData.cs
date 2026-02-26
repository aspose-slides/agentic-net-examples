using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

namespace HierarchicalChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a Sunburst chart (hierarchical chart type)
            IChart chart = slide.Shapes.AddChart(ChartType.Sunburst, 50f, 50f, 500f, 400f);

            // Enable and set the chart title
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("Hierarchical Data");

            // Remove the default sample series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Add a new series
            IChartSeries series = chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
                chart.Type);

            // Add hierarchical categories (using slash to denote hierarchy)
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Level 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Level 1/Level 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Level 1/Level 2/Level 3"));

            // Populate series data points
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 10));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

            // Save the presentation
            pres.Save("HierarchicalChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            pres.Dispose();
        }
    }
}