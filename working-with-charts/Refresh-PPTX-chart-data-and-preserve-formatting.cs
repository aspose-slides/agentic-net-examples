using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace UpdateChartDataExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input and output presentations
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // New data range to be applied to the chart
            string newDataRange = "Sheet1!$A$1:$B$5";

            // Check if the input file exists
            if (File.Exists(inputPath))
            {
                // Load existing presentation
                Presentation pres = new Presentation(inputPath);

                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Attempt to get the first shape as a chart
                IChart chart = slide.Shapes[0] as IChart;

                if (chart != null)
                {
                    // Update the chart data range
                    chart.ChartData.SetRange(newDataRange);
                }

                // Save the updated presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            else
            {
                // Create a new presentation since the input file does not exist
                Presentation pres = new Presentation();

                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a new pie chart with sample data
                IChart chart = slide.Shapes.AddChart(ChartType.Pie, 0, 0, 500, 500);

                // Set the chart data range
                chart.ChartData.SetRange(newDataRange);

                // Save the newly created presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
    }
}