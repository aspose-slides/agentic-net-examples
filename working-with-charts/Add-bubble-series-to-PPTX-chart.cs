using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace BubbleChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a bubble chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.Bubble, 50f, 50f, 600f, 400f);

            // Configure bubble chart scaling and size representation
            chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150; // Scale factor (e.g., 150%)
            chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;

            // Remove default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook
            int defaultWorksheetIndex = 0;
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Add a series
            chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);

            // Add categories (optional for bubble chart)
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

            // Populate the series with bubble data points
            IChartSeries series = chart.ChartData.Series[0];
            // Data point 1: X=1, Y=4, Size=10
            series.DataPoints.AddDataPointForBubbleSeries(
                workbook.GetCell(defaultWorksheetIndex, 1, 1, 1.0),
                workbook.GetCell(defaultWorksheetIndex, 1, 2, 4.0),
                workbook.GetCell(defaultWorksheetIndex, 1, 3, 10.0));

            // Data point 2: X=2, Y=5, Size=20
            series.DataPoints.AddDataPointForBubbleSeries(
                workbook.GetCell(defaultWorksheetIndex, 2, 1, 2.0),
                workbook.GetCell(defaultWorksheetIndex, 2, 2, 5.0),
                workbook.GetCell(defaultWorksheetIndex, 2, 3, 20.0));

            // Data point 3: X=3, Y=2, Size=15
            series.DataPoints.AddDataPointForBubbleSeries(
                workbook.GetCell(defaultWorksheetIndex, 3, 1, 3.0),
                workbook.GetCell(defaultWorksheetIndex, 3, 2, 2.0),
                workbook.GetCell(defaultWorksheetIndex, 3, 3, 15.0));

            // Define output file path
            string outputPath = "BubbleChart.pptx";

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}