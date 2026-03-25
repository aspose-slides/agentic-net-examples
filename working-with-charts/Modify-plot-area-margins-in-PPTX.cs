using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ChartPlotAreaCustomization
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a clustered column chart to the slide
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50f,   // X position
                    50f,   // Y position
                    400f,  // Width
                    300f   // Height
                );

                // Customize the plot area layout (fractions of the chart size)
                chart.PlotArea.AsILayoutable.X = 0.1f;      // 10% from left
                chart.PlotArea.AsILayoutable.Y = 0.1f;      // 10% from top
                chart.PlotArea.AsILayoutable.Width = 0.8f;  // 80% of chart width
                chart.PlotArea.AsILayoutable.Height = 0.8f; // 80% of chart height

                // Define whether layout is based on inner or outer area
                chart.PlotArea.LayoutTargetType = Aspose.Slides.Charts.LayoutTargetType.Inner;

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }

            Console.WriteLine("Presentation saved to: " + outputPath);
        }
    }
}