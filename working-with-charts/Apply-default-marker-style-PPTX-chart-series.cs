using System;
using System.IO;
using Aspose.Slides.Export;

namespace ApplyDefaultMarkers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input and output presentations
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            // Load the existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                // Iterate through all shapes on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    // Process only chart shapes
                    if (slide.Shapes[shapeIndex] is Aspose.Slides.Charts.IChart)
                    {
                        Aspose.Slides.Charts.IChart chart = (Aspose.Slides.Charts.IChart)slide.Shapes[shapeIndex];

                        // Apply default marker style to each series in the chart
                        for (int seriesIndex = 0; seriesIndex < chart.ChartData.Series.Count; seriesIndex++)
                        {
                            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[seriesIndex];
                            series.Marker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Circle; // Default marker shape
                            series.Marker.Size = 5; // Default marker size
                        }
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}