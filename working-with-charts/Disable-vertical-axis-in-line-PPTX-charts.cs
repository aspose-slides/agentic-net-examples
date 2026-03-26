using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace DisableVerticalAxis
{
    class Program
    {
        static void Main()
        {
            // Input and output file paths
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Load the presentation
            using (var presentation = new Presentation(inputPath))
            {
                // Iterate through all slides
                foreach (var slide in presentation.Slides)
                {
                    // Iterate through all shapes on the slide
                    foreach (var shape in slide.Shapes)
                    {
                        // Check if the shape is a chart
                        if (shape is IChart chart)
                        {
                            // Determine if the chart is a line chart
                            if (ChartTypeCharacterizer.IsChartTypeLine(chart.Type))
                            {
                                // Disable the vertical axis (hide its title as a simple way to "disable")
                                chart.Axes.VerticalAxis.HasTitle = false;
                            }
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
    }
}