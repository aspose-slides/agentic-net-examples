using System;
using System.IO;
using Aspose.Slides.Export;

namespace AsposeSlidesChartFormatting
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load existing presentation if it exists, otherwise create a new one
            Aspose.Slides.Presentation presentation;
            if (File.Exists(inputPath))
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                presentation = new Aspose.Slides.Presentation();

                // Add a sample PieOfPie chart to the first slide for demonstration
                Aspose.Slides.ISlide firstSlide = presentation.Slides[0];
                Aspose.Slides.Charts.IChart sampleChart = firstSlide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.PieOfPie,
                    50f, 50f, 400f, 400f);
            }

            // Iterate through all slides and their shapes
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    // Process only chart shapes
                    if (slide.Shapes[shapeIndex] is Aspose.Slides.Charts.IChart)
                    {
                        Aspose.Slides.Charts.IChart chart = (Aspose.Slides.Charts.IChart)slide.Shapes[shapeIndex];

                        // Set custom legend position and size (setlegend-custom-options rule)
                        chart.Legend.X = 10f;
                        chart.Legend.Y = 10f;
                        chart.Legend.Width = 200f;
                        chart.Legend.Height = 100f;

                        // If the chart is a PieOfPie, apply second plot options (second-plot-optionsfor-charts rule)
                        if (chart.Type == Aspose.Slides.Charts.ChartType.PieOfPie)
                        {
                            // Assuming the first series is the target
                            int seriesIndex = 0;

                            // Show values on data labels
                            chart.ChartData.Series[seriesIndex].Labels.DefaultDataLabelFormat.ShowValue = true;

                            // Configure second pie size, split type and position
                            chart.ChartData.Series[seriesIndex].ParentSeriesGroup.SecondPieSize = 50; // UInt16
                            chart.ChartData.Series[seriesIndex].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
                            chart.ChartData.Series[seriesIndex].ParentSeriesGroup.PieSplitPosition = 30.0; // Double
                        }
                    }
                }
            }

            // Save the modified presentation (must save before exit)
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}