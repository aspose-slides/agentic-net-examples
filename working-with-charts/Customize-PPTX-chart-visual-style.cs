using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ChartStylingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect input and output file paths as arguments
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: ChartStylingExample <input.pptx> <output.pptx>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Error: Input file '{inputPath}' not found.");
                return;
            }

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Add a Sunburst chart to the first slide
                IChart chart = presentation.Slides[0].Shapes.AddChart(
                    ChartType.Sunburst,
                    0f, 0f, 500f, 500f);

                // Access the data points of the first series
                IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

                // Show value for a specific data point level
                dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;

                // Customize label for another data point level
                IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
                branch1Label.DataLabelFormat.ShowCategoryName = true;
                branch1Label.DataLabelFormat.ShowSeriesName = true;
                branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
                branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Yellow;

                // Change fill color of a specific data point
                IFormat steam4Format = dataPoints[9].Format;
                steam4Format.Fill.FillType = FillType.Solid;
                steam4Format.Fill.SolidFillColor.Color = System.Drawing.Color.FromArgb(255, 0, 128, 0); // Example ARGB color

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }

            Console.WriteLine("Presentation saved successfully.");
        }
    }
}