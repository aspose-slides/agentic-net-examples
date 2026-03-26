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
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load existing presentation if it exists, otherwise create a new one
        Presentation pres;
        if (File.Exists(inputPath))
        {
            pres = new Presentation(inputPath);
        }
        else
        {
            pres = new Presentation();
        }

        // Get the first slide
        ISlide slide = pres.Slides[0];

        // Add a clustered column chart
        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

        // Add a linear trendline to the first series and set its visual attributes
        ITrendline linearTrend = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
        linearTrend.DisplayEquation = false;
        linearTrend.DisplayRSquaredValue = false;
        linearTrend.Format.Line.FillFormat.FillType = FillType.Solid;
        linearTrend.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

        // Add an exponential trendline to the second series and set its visual attributes
        ITrendline exponentialTrend = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Exponential);
        exponentialTrend.DisplayEquation = true;
        exponentialTrend.DisplayRSquaredValue = true;
        exponentialTrend.Format.Line.FillFormat.FillType = FillType.Solid;
        exponentialTrend.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;

        // Save the presentation
        pres.Save(outputPath, SaveFormat.Pptx);
    }
}