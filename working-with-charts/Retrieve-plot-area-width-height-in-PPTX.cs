using System;
using System.IO;
using Aspose.Slides;
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

        Presentation pres = null;
        try
        {
            pres = new Presentation(inputPath);
            ISlide slide = pres.Slides[0];
            Aspose.Slides.Charts.IChart chart = null;
            foreach (IShape shape in slide.Shapes)
            {
                chart = shape as Aspose.Slides.Charts.IChart;
                if (chart != null)
                {
                    break;
                }
            }

            if (chart == null)
            {
                Console.WriteLine("No chart found in the presentation.");
            }
            else
            {
                chart.ValidateChartLayout();
                double plotX = chart.PlotArea.ActualX;
                double plotY = chart.PlotArea.ActualY;
                double plotWidth = chart.PlotArea.ActualWidth;
                double plotHeight = chart.PlotArea.ActualHeight;

                Console.WriteLine("Plot Area X: " + plotX);
                Console.WriteLine("Plot Area Y: " + plotY);
                Console.WriteLine("Plot Area Width: " + plotWidth);
                Console.WriteLine("Plot Area Height: " + plotHeight);
            }

            pres.Save(outputPath, SaveFormat.Pptx);
        }
        finally
        {
            if (pres != null)
            {
                pres.Dispose();
            }
        }
    }
}