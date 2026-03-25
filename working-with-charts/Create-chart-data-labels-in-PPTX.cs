using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartAutomation
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "Data\\input.pptx";
            string outputPath = "Data\\output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation not found: " + inputPath);
                return;
            }

            using (Presentation pres = new Presentation(inputPath))
            {
                if (pres.Slides.Count == 0)
                {
                    Console.WriteLine("Presentation contains no slides.");
                }
                else
                {
                    ISlide slide = pres.Slides[0];
                    IChart chart = null;

                    foreach (IShape shape in slide.Shapes)
                    {
                        chart = shape as IChart;
                        if (chart != null)
                        {
                            break;
                        }
                    }

                    if (chart == null)
                    {
                        chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0f, 0f, 500f, 400f);
                    }

                    chart.HasTitle = true;
                    chart.ChartTitle.AddTextFrameForOverriding("Modified Chart");

                    if (chart.ChartData.Series.Count > 0)
                    {
                        IChartSeries series = chart.ChartData.Series[0];
                        series.Labels.DefaultDataLabelFormat.ShowValue = true;
                    }
                }

                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
    }
}