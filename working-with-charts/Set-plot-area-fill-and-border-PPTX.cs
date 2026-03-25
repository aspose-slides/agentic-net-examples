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

        Presentation pres = null;
        if (File.Exists(inputPath))
        {
            pres = new Presentation(inputPath);
        }
        else
        {
            Console.WriteLine("Input file not found: " + inputPath);
            pres = new Presentation();
        }

        // Ensure there is at least one slide
        if (pres.Slides.Count == 0)
        {
            pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
        }

        // Add a chart if none exists on the first slide
        IChart chart = null;
        if (pres.Slides[0].Shapes.Count == 0 || !(pres.Slides[0].Shapes[0] is IChart))
        {
            chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 400, 300);
        }
        else
        {
            chart = (IChart)pres.Slides[0].Shapes[0];
        }

        // Configure plot area fill color
        chart.PlotArea.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightGray;

        // Configure plot area border (line) properties
        chart.PlotArea.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        chart.PlotArea.Format.Line.FillFormat.SolidFillColor.Color = Color.Black;
        chart.PlotArea.Format.Line.Width = 2;

        // Save the presentation
        pres.Save(outputPath, SaveFormat.Pptx);
        pres.Dispose();
    }
}