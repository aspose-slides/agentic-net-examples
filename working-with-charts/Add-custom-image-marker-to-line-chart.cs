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
            string imagePath = "marker.png";
            string outputPath = "output.pptx";

            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Image file not found: " + imagePath);
                return;
            }

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a line chart with markers
                IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 0, 0, 400, 400);

                // Prepare chart data workbook
                int defaultWorksheetIndex = 0;
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add a series
                chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
                IChartSeries series = chart.ChartData.Series[0];

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 4, 0, "Category 4"));

                // Add data points
                IChartDataPoint point1 = series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 10));
                IChartDataPoint point2 = series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
                IChartDataPoint point3 = series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));
                IChartDataPoint point4 = series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 40));

                // Load custom image and add to presentation images collection
                IImage img = Images.FromFile(imagePath);
                IPPImage imgx = presentation.Images.AddImage(img);

                // Set custom image marker for the third data point
                point3.Marker.Format.Fill.FillType = FillType.Picture;
                point3.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx;

                // Optionally set marker size
                point3.Marker.Size = 20;

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                // Format not supported exception handling can be added here if needed
            }
        }
    }
}