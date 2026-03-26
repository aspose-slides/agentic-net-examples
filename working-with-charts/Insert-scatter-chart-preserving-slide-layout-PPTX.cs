using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ScatterChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load existing presentation if it exists; otherwise create a new one
            Presentation presentation;
            if (File.Exists(inputPath))
            {
                presentation = new Presentation(inputPath);
            }
            else
            {
                presentation = new Presentation();
            }

            // Access the first slide (preserve its existing layout)
            ISlide slide = presentation.Slides[0];

            // Add a scatter chart to the slide
            IChart chart = slide.Shapes.AddChart(
                ChartType.ScatterWithSmoothLines,
                0f, 0f, 400f, 400f);

            // Get the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Clear any default series and categories
            chart.ChartData.Series.Clear();

            // Add two series with names
            chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"),
                chart.Type);
            chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"),
                chart.Type);

            // Populate the first series with data points
            IChartSeries series1 = chart.ChartData.Series[0];
            series1.DataPoints.AddDataPointForScatterSeries(
                workbook.GetCell(defaultWorksheetIndex, 2, 1, 1),
                workbook.GetCell(defaultWorksheetIndex, 2, 2, 3));
            series1.DataPoints.AddDataPointForScatterSeries(
                workbook.GetCell(defaultWorksheetIndex, 3, 1, 2),
                workbook.GetCell(defaultWorksheetIndex, 3, 2, 10));
            series1.Type = ChartType.ScatterWithStraightLinesAndMarkers;
            series1.Marker.Size = 10;
            series1.Marker.Symbol = MarkerStyleType.Star;

            // Populate the second series with data points
            IChartSeries series2 = chart.ChartData.Series[1];
            series2.DataPoints.AddDataPointForScatterSeries(
                workbook.GetCell(defaultWorksheetIndex, 2, 3, 5),
                workbook.GetCell(defaultWorksheetIndex, 2, 4, 2));
            series2.DataPoints.AddDataPointForScatterSeries(
                workbook.GetCell(defaultWorksheetIndex, 3, 3, 3),
                workbook.GetCell(defaultWorksheetIndex, 3, 4, 1));
            series2.DataPoints.AddDataPointForScatterSeries(
                workbook.GetCell(defaultWorksheetIndex, 4, 3, 2),
                workbook.GetCell(defaultWorksheetIndex, 4, 4, 2));
            series2.DataPoints.AddDataPointForScatterSeries(
                workbook.GetCell(defaultWorksheetIndex, 5, 3, 5),
                workbook.GetCell(defaultWorksheetIndex, 5, 4, 1));
            series2.Marker.Size = 10;
            series2.Marker.Symbol = MarkerStyleType.Circle;

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}