using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AddPercentageDataLabels
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                        // Process only chart shapes
                        if (shape is Aspose.Slides.Charts.IChart)
                        {
                            Aspose.Slides.Charts.IChart chart = (Aspose.Slides.Charts.IChart)shape;

                            // Enable percentage display for each series in the chart
                            for (int seriesIndex = 0; seriesIndex < chart.ChartData.Series.Count; seriesIndex++)
                            {
                                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[seriesIndex];
                                series.Labels.DefaultDataLabelFormat.ShowPercentage = true;
                            }
                        }
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
        }
    }
}