using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ScatterChartCustomMarker
{
    class Program
    {
        static void Main()
        {
            // Output file path
            string outputPath = "ScatterChartCustomMarker.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a scatter chart with smooth lines
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ScatterWithSmoothLines,
                0f, 0f, 400f, 400f);

            // Access the chart's data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Clear any default series
            chart.ChartData.Series.Clear();

            // Add a new series
            chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
                chart.Type);

            // Get the created series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

            // Add data points to the series
            series.DataPoints.AddDataPointForScatterSeries(
                workbook.GetCell(defaultWorksheetIndex, 1, 1, 1),
                workbook.GetCell(defaultWorksheetIndex, 1, 2, 3));

            series.DataPoints.AddDataPointForScatterSeries(
                workbook.GetCell(defaultWorksheetIndex, 2, 1, 2),
                workbook.GetCell(defaultWorksheetIndex, 2, 2, 5));

            // Apply a custom marker shape and size to all data points in the series
            series.Marker.Size = 10;
            series.Marker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Star;

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}