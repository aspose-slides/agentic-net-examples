using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
                    if (chart == null)
                        continue;

                    if (!Aspose.Slides.Charts.ChartTypeCharacterizer.HasSeriesTrendLines(chart.Type))
                        continue;

                    for (int i = 0; i < chart.ChartData.Series.Count; i++)
                    {
                        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[i];
                        Aspose.Slides.Charts.ITrendline trendline = series.TrendLines.Add(Aspose.Slides.Charts.TrendlineType.Linear);
                        trendline.DisplayEquation = false;
                        trendline.DisplayRSquaredValue = false;
                    }
                }
            }

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}