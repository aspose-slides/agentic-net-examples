using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ApplyCustomMarkerShapeToScatterSeries
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a scatter chart with smooth lines
            IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

            // Access the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Clear any default series and categories
            chart.ChartData.Series.Clear();

            // Add two series with names
            chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
            chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

            // Populate first series with data points
            IChartSeries series1 = chart.ChartData.Series[0];
            series1.DataPoints.AddDataPointForScatterSeries(
                workbook.GetCell(defaultWorksheetIndex, 2, 1, 1),
                workbook.GetCell(defaultWorksheetIndex, 2, 2, 3));
            series1.DataPoints.AddDataPointForScatterSeries(
                workbook.GetCell(defaultWorksheetIndex, 3, 1, 2),
                workbook.GetCell(defaultWorksheetIndex, 3, 2, 10));

            // Populate second series with data points
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

            // Apply custom marker shape and size to the entire first series
            series1.Marker.Symbol = MarkerStyleType.Star;
            series1.Marker.Size = 10;

            // Apply custom marker shape and size to each data point in the first series
            foreach (IChartDataPoint dataPoint in series1.DataPoints)
            {
                dataPoint.Marker.Symbol = MarkerStyleType.Star;
                dataPoint.Marker.Size = 10;
            }

            // Apply custom marker shape and size to the entire second series
            series2.Marker.Symbol = MarkerStyleType.Circle;
            series2.Marker.Size = 10;

            // Apply custom marker shape and size to each data point in the second series
            foreach (IChartDataPoint dataPoint in series2.DataPoints)
            {
                dataPoint.Marker.Symbol = MarkerStyleType.Circle;
                dataPoint.Marker.Size = 10;
            }

            // Save the presentation
            try
            {
                string outputPath = "ScatterChartWithCustomMarkers.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during saving (e.g., unsupported format)
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}