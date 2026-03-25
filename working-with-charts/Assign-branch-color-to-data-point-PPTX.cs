using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using System.Drawing;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        using (Presentation presentation = new Presentation(inputPath))
        {
            IChart chart = presentation.Slides[0].Shapes[0] as IChart;
            if (chart != null)
            {
                IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
                IChartDataPoint point = dataPoints[3];
                point.Format.Fill.FillType = FillType.Solid;
                point.Format.Fill.SolidFillColor.Color = Color.FromArgb(255, 255, 0, 0); // Red color
            }

            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}