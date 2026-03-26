using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace LegendAdjustmentExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load existing presentation if it exists; otherwise create a new one
            Presentation presentation;
            if (File.Exists(inputPath))
            {
                presentation = new Presentation(inputPath);
            }
            else
            {
                presentation = new Presentation();
            }

            // Ensure there is at least one slide
            ISlide slide;
            if (presentation.Slides.Count > 0)
            {
                slide = presentation.Slides[0];
            }
            else
            {
                slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            }

            // Add a clustered column chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 450f, 300f);

            // Adjust legend position and size (fraction of chart dimensions)
            chart.Legend.X = 0.7f;      // 70% from the left of the chart
            chart.Legend.Y = 0.1f;      // 10% from the top of the chart
            chart.Legend.Width = 0.2f;  // 20% of chart width
            chart.Legend.Height = 0.2f; // 20% of chart height

            // Optionally set a predefined legend position (overrides X/Y if not NaN)
            // chart.Legend.Position = LegendPositionType.TopRight;

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}