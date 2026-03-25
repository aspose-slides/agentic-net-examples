using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input file path (if provided)
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                // Create a new presentation if the file does not exist
                using (Presentation pres = new Presentation())
                {
                    CreateChartWithCustomMarkers(pres);
                    pres.Save("output.pptx", SaveFormat.Pptx);
                }
                return;
            }

            // Load existing presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Ensure there is at least one slide
                if (pres.Slides.Count == 0)
                {
                    pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
                }

                // Add a chart and customize its data markers
                CreateChartWithCustomMarkers(pres);

                // Save the modified presentation
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
        }

        private static void CreateChartWithCustomMarkers(Presentation pres)
        {
            // Add a line chart to the first slide
            IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 50f, 50f, 500f, 400f);

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get reference to the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Add two series
            IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
            IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

            // Add three categories
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

            // Populate data points for series 1
            series1.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 20));
            series1.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
            series1.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

            // Populate data points for series 2
            series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 30));
            series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 10));
            series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 60));

            // Customize marker for series 1
            series1.Marker.Size = 12;
            series1.Marker.Symbol = MarkerStyleType.Circle;
            series1.Marker.Format.Fill.FillType = FillType.Solid;
            series1.Marker.Format.Fill.SolidFillColor.Color = Color.Red;

            // Customize marker for series 2
            series2.Marker.Size = 12;
            series2.Marker.Symbol = MarkerStyleType.Square;
            series2.Marker.Format.Fill.FillType = FillType.Solid;
            series2.Marker.Format.Fill.SolidFillColor.Color = Color.Green;
        }
    }
}