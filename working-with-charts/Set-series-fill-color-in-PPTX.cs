using System;
using System.IO;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
        {
            Aspose.Slides.ISlide slide = pres.Slides[0];
            Aspose.Slides.IShape shape = slide.Shapes[0];
            Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
            if (chart != null)
            {
                chart.ChartData.Series[0].Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                chart.ChartData.Series[0].Format.Fill.SolidFillColor.Color = Color.Blue;
            }

            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}