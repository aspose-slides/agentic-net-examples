using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace DefaultMarkersChart
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a line chart without sample data
            IChart chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 500, 400, false);

            // Index of the default worksheet
            int defaultWorksheetIndex = 0;

            // Get the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Clear any default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add two series
            chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
            chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

            // Add two categories
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));

            // Populate first series with data points
            IChartSeries series1 = chart.ChartData.Series[0];
            series1.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 10));
            series1.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));

            // Populate second series with data points
            IChartSeries series2 = chart.ChartData.Series[1];
            series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 30));
            series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 15));

            // Apply default markers to both series
            series1.Marker.Size = 7;
            series1.Marker.Symbol = MarkerStyleType.Circle;

            series2.Marker.Size = 7;
            series2.Marker.Symbol = MarkerStyleType.Circle;

            // Save the presentation
            pres.Save("DefaultMarkersChart_out.pptx", SaveFormat.Pptx);
        }
    }
}