using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AreaChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add an Area chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.Area, 50f, 50f, 500f, 400f);

            // Index of the default worksheet
            int defaultWorksheetIndex = 0;

            // Access the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Remove default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add two series
            IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), ChartType.Area);
            IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), ChartType.Area);

            // Add three categories
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

            // Populate data for the first series
            series1.DataPoints.AddDataPointForAreaSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 10));
            series1.DataPoints.AddDataPointForAreaSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
            series1.DataPoints.AddDataPointForAreaSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

            // Populate data for the second series
            series2.DataPoints.AddDataPointForAreaSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 15));
            series2.DataPoints.AddDataPointForAreaSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 25));
            series2.DataPoints.AddDataPointForAreaSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 35));

            // Add a title to the chart
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("Area Chart Example");

            // Save the presentation
            pres.Save("AreaChart_out.pptx", SaveFormat.Pptx);

            // Clean up
            pres.Dispose();
        }
    }
}