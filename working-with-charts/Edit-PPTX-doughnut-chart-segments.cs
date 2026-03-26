using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }

        var pres = new Aspose.Slides.Presentation(inputPath);
        var slide = pres.Slides[0];
        var chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;

        if (chart == null || chart.Type != Aspose.Slides.Charts.ChartType.Doughnut)
        {
            Console.WriteLine("No doughnut chart found.");
            pres.Dispose();
            return;
        }

        // Adjust series group properties
        chart.ChartData.Series[0].ParentSeriesGroup.FirstSliceAngle = 45;
        chart.ChartData.Series[0].ParentSeriesGroup.DoughnutHoleSize = 30;

        // Modify existing data point color
        var firstPoint = chart.ChartData.Series[0].DataPoints[0];
        firstPoint.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        firstPoint.Format.Fill.SolidFillColor.Color = System.Drawing.Color.Red;

        // Add a new data point with custom value and color
        var newPoint = chart.ChartData.Series[0].DataPoints.AddDataPointForDoughnutSeries(75);
        newPoint.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        newPoint.Format.Fill.SolidFillColor.Color = System.Drawing.Color.Green;

        // Save the modified presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}