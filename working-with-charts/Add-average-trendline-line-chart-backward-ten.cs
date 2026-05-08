using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesTrendlineExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a line chart on the first slide
                ISlide slide = presentation.Slides[0];
                IChart chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 500, 400);

                // Prepare chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                int defaultWorksheetIndex = 0;

                // Add a series
                chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
                IChartSeries series = chart.ChartData.Series[0];

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 4, 0, "Category 4"));

                // Add data points for the series
                series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 10));
                series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
                series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 15));
                series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 25));

                // Add a moving average trend line (average trend line) to the series
                ITrendline trendline = series.TrendLines.Add(TrendlineType.MovingAverage);
                // Configure the backward length to cover ten points
                trendline.Backward = 10;

                // Save the presentation
                string outputPath = "AverageTrendLinePresentation.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                // Handle missing input file scenario
                Console.WriteLine("Input file not found: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}