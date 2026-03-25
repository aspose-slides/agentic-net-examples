using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the existing presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Access the first slide (preserving its layout)
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a scatter chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ScatterWithSmoothLines,
                0, 0, 400, 400);

            // Get the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Clear default series and add custom series
            chart.ChartData.Series.Clear();
            chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
            chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

            // Populate first series with scatter data points
            Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series[0];
            series1.DataPoints.AddDataPointForScatterSeries(
                workbook.GetCell(defaultWorksheetIndex, 2, 1, 1),
                workbook.GetCell(defaultWorksheetIndex, 2, 2, 3));
            series1.DataPoints.AddDataPointForScatterSeries(
                workbook.GetCell(defaultWorksheetIndex, 3, 1, 2),
                workbook.GetCell(defaultWorksheetIndex, 3, 2, 10));
            series1.Type = Aspose.Slides.Charts.ChartType.ScatterWithStraightLinesAndMarkers;
            series1.Marker.Size = 10;
            series1.Marker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Star;

            // Populate second series with scatter data points
            Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series[1];
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
            series2.Marker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Circle;

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}