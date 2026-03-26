using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        Aspose.Slides.IShape shape = slide.Shapes[0];
        Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;

        if (chart != null && chart.ChartData.Series.Count > 0)
        {
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];
            System.Drawing.Color automaticColor = series.GetAutomaticSeriesColor();
            Console.WriteLine("Automatic series color: " + automaticColor.ToString());

            series.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            series.Format.Fill.SolidFillColor.Color = automaticColor;
        }

        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}