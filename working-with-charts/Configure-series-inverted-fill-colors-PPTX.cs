using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace InvertedSeriesColorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a clustered column chart to the first slide
                IChart chart = presentation.Slides[0].Shapes.AddChart(
                    ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

                // Access the first series of the chart
                IChartSeries series = chart.ChartData.Series[0];

                // Set the series fill type to solid
                series.Format.Fill.FillType = FillType.Solid;

                // Configure the inverted solid fill color for the series
                series.InvertedSolidFillColor.Color = Color.Blue;

                // Define output file path
                string outputPath = "InvertedSeriesColor.pptx";

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Input file not found: " + ex.FileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}