using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Verify arguments
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: program <input.pptx> <output.pptx>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Check input file existence
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                // Iterate through all shapes on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                    Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;

                    if (chart != null)
                    {
                        // Apply custom legend positioning (setlegend-custom-options rule)
                        chart.Legend.X = 10f;
                        chart.Legend.Y = 10f;
                        chart.Legend.Width = 200f;
                        chart.Legend.Height = 100f;

                        // Apply second plot options for PieOfPie charts (second-plot-optionsfor-charts rule)
                        if (chart.Type == Aspose.Slides.Charts.ChartType.PieOfPie && chart.ChartData.Series.Count > 0)
                        {
                            int seriesIdx = 0;
                            chart.ChartData.Series[seriesIdx].Labels.DefaultDataLabelFormat.ShowValue = true;
                            chart.ChartData.Series[seriesIdx].ParentSeriesGroup.SecondPieSize = 50;
                            chart.ChartData.Series[seriesIdx].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
                            chart.ChartData.Series[seriesIdx].ParentSeriesGroup.PieSplitPosition = 30.0;
                        }
                    }
                }
            }

            // Save the modified presentation (save before exit)
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}