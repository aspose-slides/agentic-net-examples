using System;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file path
            string outputPath = "SetChartMarkerOptions_out.pptx";
            // Image file paths (ensure these files exist)
            string imagePath1 = "image1.png";
            string imagePath2 = "image2.png";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a line chart with markers
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.LineWithMarkers,
                0f, 0f, 400f, 400f);

            int defaultWorksheetIndex = 0;
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Clear any default series
            chart.ChartData.Series.Clear();

            // Add a series
            chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"),
                chart.Type);

            // Load images and add them to the presentation
            Aspose.Slides.IImage img1 = Aspose.Slides.Images.FromFile(imagePath1);
            Aspose.Slides.IPPImage imgx1 = presentation.Images.AddImage(img1);
            Aspose.Slides.IImage img2 = Aspose.Slides.Images.FromFile(imagePath2);
            Aspose.Slides.IPPImage imgx2 = presentation.Images.AddImage(img2);

            // Get the series reference
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

            // Data point 1
            Aspose.Slides.Charts.IChartDataPoint point1 = series.DataPoints.AddDataPointForLineSeries(
                workbook.GetCell(defaultWorksheetIndex, 1, 1, 10));
            point1.Marker.Format.Fill.FillType = Aspose.Slides.FillType.Picture;
            point1.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

            // Data point 2
            Aspose.Slides.Charts.IChartDataPoint point2 = series.DataPoints.AddDataPointForLineSeries(
                workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
            point2.Marker.Format.Fill.FillType = Aspose.Slides.FillType.Picture;
            point2.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

            // Data point 3
            Aspose.Slides.Charts.IChartDataPoint point3 = series.DataPoints.AddDataPointForLineSeries(
                workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));
            point3.Marker.Format.Fill.FillType = Aspose.Slides.FillType.Picture;
            point3.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

            // Data point 4
            Aspose.Slides.Charts.IChartDataPoint point4 = series.DataPoints.AddDataPointForLineSeries(
                workbook.GetCell(defaultWorksheetIndex, 4, 1, 40));
            point4.Marker.Format.Fill.FillType = Aspose.Slides.FillType.Picture;
            point4.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

            // Set marker size for the series
            series.Marker.Size = 10;

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}