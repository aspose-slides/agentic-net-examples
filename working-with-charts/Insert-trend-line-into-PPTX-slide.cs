using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

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

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

            Aspose.Slides.Charts.ITrendline trendExp = chart.ChartData.Series[0].TrendLines.Add(Aspose.Slides.Charts.TrendlineType.Exponential);
            trendExp.DisplayEquation = false;
            trendExp.DisplayRSquaredValue = false;

            Aspose.Slides.Charts.ITrendline trendLin = chart.ChartData.Series[1].TrendLines.Add(Aspose.Slides.Charts.TrendlineType.Linear);
            trendLin.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            trendLin.Format.Line.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;

            Aspose.Slides.Charts.ITrendline trendPoly = chart.ChartData.Series[0].TrendLines.Add(Aspose.Slides.Charts.TrendlineType.Polynomial);
            trendPoly.Order = 3;
            trendPoly.Forward = 2;

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}