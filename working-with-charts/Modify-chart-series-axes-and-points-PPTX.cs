using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Assume the first shape on the slide is a chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;
        if (chart != null)
        {
            // Change the data range of the chart
            chart.ChartData.SetRange("Sheet1!$A$1:$B$5");

            // Set the horizontal axis to be positioned between categories
            chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

            // Set category axis label distance
            chart.Axes.HorizontalAxis.LabelOffset = (ushort)10;

            // Change category axis type to Date and configure major unit
            chart.Axes.HorizontalAxis.CategoryAxisType = Aspose.Slides.Charts.CategoryAxisType.Date;
            chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
            chart.Axes.HorizontalAxis.MajorUnit = 1;
            chart.Axes.HorizontalAxis.MajorUnitScale = Aspose.Slides.Charts.TimeUnitType.Months;

            // Customize data labels for the first series
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLeaderLines = true;
            chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowValue = true;
            chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowCategoryName = true;
            chart.ChartData.Series[0].Labels[0].DataLabelFormat.Separator = "/";

            // Modify a data point value directly
            chart.ChartData.Series[0].DataPoints[0].Value.Data = 42.0;

            // Add solid fill color to the third data point
            Aspose.Slides.Charts.IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
            dataPoints[2].Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            dataPoints[2].Format.Fill.SolidFillColor.Color = Color.Yellow;

            // Set a picture marker for the first data point
            Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile("marker.png");
            Aspose.Slides.IPPImage imgx = pres.Images.AddImage(img);
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];
            Aspose.Slides.Charts.IChartDataPoint point = series.DataPoints[0];
            point.Marker.Format.Fill.FillType = Aspose.Slides.FillType.Picture;
            point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx;
        }

        // Save the modified presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}