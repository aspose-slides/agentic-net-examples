using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesTrendlineExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "ScatterTrendline.pptx");

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a scatter chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ScatterWithSmoothLines,
                    0f, 0f, 400f, 400f);

                // Get the chart data workbook
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                int defaultWorksheetIndex = 0;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add two series
                chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
                chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

                // Add data points to the first series
                Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series[0];
                series1.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 1.0), workbook.GetCell(defaultWorksheetIndex, 2, 2, 2.0));
                series1.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 2.0), workbook.GetCell(defaultWorksheetIndex, 3, 2, 3.5));
                series1.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 3.0), workbook.GetCell(defaultWorksheetIndex, 4, 2, 5.0));

                // Add a linear trendline to the first series and display its equation
                Aspose.Slides.Charts.ITrendline trendline = series1.TrendLines.Add(Aspose.Slides.Charts.TrendlineType.Linear);
                trendline.DisplayEquation = true;
                trendline.DisplayRSquaredValue = false;

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format, file I/O errors)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}