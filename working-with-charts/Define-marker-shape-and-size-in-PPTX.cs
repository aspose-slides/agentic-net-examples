using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartMarkerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to an optional input presentation
            string inputPath = "input.pptx";
            // Path for the output presentation
            string outputPath = "ChartMarkerOutput.pptx";

            // Create or load the presentation
            Aspose.Slides.Presentation presentation;
            if (File.Exists(inputPath))
            {
                // Load existing presentation
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                // Create a new presentation with a default slide
                presentation = new Aspose.Slides.Presentation();
            }

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a line chart with markers
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.LineWithMarkers,
                50f, 50f, 500f, 400f);

            // Ensure the chart has at least one series
            if (chart.ChartData.Series.Count == 0)
            {
                // Add a sample series if none exist
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
                // Add a couple of sample categories
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
                // Add sample data points
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];
                series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 1, 10));
                series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 1, 20));
            }

            // Get the first series
            Aspose.Slides.Charts.IChartSeries firstSeries = chart.ChartData.Series[0];

            // Set marker size and style for the entire series
            firstSeries.Marker.Size = 10;
            firstSeries.Marker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Circle;

            // Customize marker for the first data point
            Aspose.Slides.Charts.IChartDataPoint firstPoint = firstSeries.DataPoints[0];
            firstPoint.Marker.Size = 12;
            firstPoint.Marker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Diamond;

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation object
            presentation.Dispose();
        }
    }
}