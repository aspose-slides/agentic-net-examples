using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ChartStylingExample
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
            using (Presentation pres = new Presentation(inputPath))
            {
                // Attempt to retrieve the first chart on the first slide
                IChart chart = pres.Slides[0].Shapes[0] as IChart;
                if (chart != null)
                {
                    // Change the fill color of the first data point in the first series
                    IChartDataPoint point = chart.ChartData.Series[0].DataPoints[0];
                    point.Format.Fill.FillType = FillType.Solid;
                    point.Format.Fill.SolidFillColor.Color = Color.Blue;

                    // Add a new Sunburst chart to demonstrate adding color to data points
                    IChart sunburstChart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 50f, 50f, 400f, 300f);
                    IChartDataPointCollection dataPoints = sunburstChart.ChartData.Series[0].DataPoints;

                    // Configure label formatting for a specific data point level
                    IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
                    branch1Label.DataLabelFormat.ShowCategoryName = true;
                    branch1Label.DataLabelFormat.ShowSeriesName = true;
                    branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
                    branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
    }
}