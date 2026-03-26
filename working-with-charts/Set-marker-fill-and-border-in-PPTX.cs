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
            Console.WriteLine("Input file not found.");
            return;
        }

        using (Presentation pres = new Presentation(inputPath))
        {
            ISlide slide = pres.Slides[0];
            IChart chart = slide.Shapes[0] as IChart;
            if (chart == null)
            {
                Console.WriteLine("No chart found on the first slide.");
                return;
            }

            IChartSeries series = chart.ChartData.Series[0];

            // Set marker style
            series.Marker.Symbol = MarkerStyleType.Circle;

            // Set marker fill color
            series.Marker.Format.Fill.FillType = FillType.Solid;
            series.Marker.Format.Fill.SolidFillColor.Color = Color.Blue;

            // Set marker border (line) properties
            series.Marker.Format.Line.FillFormat.FillType = FillType.Solid;
            series.Marker.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
            series.Marker.Format.Line.Width = 2;

            // Enable varied colors for markers
            series.ParentSeriesGroup.IsColorVaried = true;

            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}