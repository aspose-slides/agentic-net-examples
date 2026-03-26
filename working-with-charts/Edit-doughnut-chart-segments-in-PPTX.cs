using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for input and output presentations
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }

        // Load the existing presentation
        var pres = new Aspose.Slides.Presentation(inputPath);

        // Access the first slide
        var slide = pres.Slides[0];

        // Assume the first shape is a doughnut chart
        var chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;
        if (chart == null || chart.Type != Aspose.Slides.Charts.ChartType.Doughnut)
        {
            Console.WriteLine("No doughnut chart found on the first slide.");
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            return;
        }

        // Adjust the angle of the first slice
        chart.ChartData.Series[0].ParentSeriesGroup.FirstSliceAngle = 45; // 45 degrees

        // Adjust the size of the doughnut hole (percentage of plot area)
        chart.ChartData.Series[0].ParentSeriesGroup.DoughnutHoleSize = 50; // 50%

        // Modify data points: add new points with custom values and colors
        var series = chart.ChartData.Series[0];

        // Add a new data point with value 40 and set its fill color to Red
        var point1 = series.DataPoints.AddDataPointForDoughnutSeries(40);
        point1.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        point1.Format.Fill.SolidFillColor.Color = Color.Red;

        // Add a new data point with value 20 and set its fill color to Green
        var point2 = series.DataPoints.AddDataPointForDoughnutSeries(20);
        point2.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        point2.Format.Fill.SolidFillColor.Color = Color.Green;

        // Add a new data point with value 10 and set its fill color to Blue
        var point3 = series.DataPoints.AddDataPointForDoughnutSeries(10);
        point3.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        point3.Format.Fill.SolidFillColor.Color = Color.Blue;

        // Save the modified presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}