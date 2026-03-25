using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartDataPointLabelExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Add a Sunburst chart to the first slide
                IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Sunburst, 50f, 50f, 500f, 400f);

                // Access the first series data points collection
                IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

                // Choose a data point (e.g., the first one) and its first level
                IDataLabel label = dataPoints[0].DataPointLevels[0].Label;

                // Set custom label text
                label.AddTextFrameForOverriding("Custom Label");

                // Set fill color for the label
                label.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
                label.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}