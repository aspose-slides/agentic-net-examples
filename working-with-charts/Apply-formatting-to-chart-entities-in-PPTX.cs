using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartFormattingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a Sunburst chart
                IChart chart = slide.Shapes.AddChart(ChartType.Sunburst, 50f, 50f, 500f, 400f);

                // Access data points of the first series
                IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

                // Show value for a specific data point level
                dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;

                // Customize label for the first branch
                IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
                branch1Label.DataLabelFormat.ShowCategoryName = true;
                branch1Label.DataLabelFormat.ShowSeriesName = true;
                branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
                branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;

                // Apply solid fill to a specific data point format
                IFormat steam4Format = dataPoints[9].Format;
                steam4Format.Fill.FillType = FillType.Solid;
                steam4Format.Fill.SolidFillColor.Color = Color.FromArgb(255, 0, 128, 255); // Example ARGB color

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }

            Console.WriteLine("Presentation saved to " + outputPath);
        }
    }
}