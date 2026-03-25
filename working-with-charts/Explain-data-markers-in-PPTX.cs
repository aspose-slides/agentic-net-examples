using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace DataMarkersDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for marker images and output presentation
            string imagePath1 = "marker1.png";
            string imagePath2 = "marker2.png";
            string outputPath = "DataMarkersPresentation.pptx";

            // Verify that marker image files exist
            if (!File.Exists(imagePath1))
            {
                Console.WriteLine($"Error: Image file not found - {imagePath1}");
                return;
            }
            if (!File.Exists(imagePath2))
            {
                Console.WriteLine($"Error: Image file not found - {imagePath2}");
                return;
            }

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

            // Add data points with numeric values
            IChartDataPoint point1 = series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 10));
            IChartDataPoint point2 = series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
            IChartDataPoint point3 = series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));
            IChartDataPoint point4 = series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 40));

            // Load images into the presentation
            IImage img1 = Images.FromFile(imagePath1);
            IPPImage imgx1 = presentation.Images.AddImage(img1);
            IImage img2 = Images.FromFile(imagePath2);
            IPPImage imgx2 = presentation.Images.AddImage(img2);

            // Apply picture markers to individual data points
            point1.Marker.Format.Fill.FillType = FillType.Picture;
            point1.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

            point2.Marker.Format.Fill.FillType = FillType.Picture;
            point2.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

            point3.Marker.Format.Fill.FillType = FillType.Picture;
            point3.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

            point4.Marker.Format.Fill.FillType = FillType.Picture;
            point4.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

            // Set default marker size and style for the series (applies to points without custom picture)
            series.Marker.Size = 10; // size in points
            series.Marker.Symbol = MarkerStyleType.Circle;

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}