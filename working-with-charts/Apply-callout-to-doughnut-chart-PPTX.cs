using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ApplyCalloutToDoughnutChart
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
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Access the first slide
                    ISlide slide = pres.Slides[0];

                    // Find the first chart on the slide
                    IChart chart = null;
                    foreach (IShape shape in slide.Shapes)
                    {
                        chart = shape as IChart;
                        if (chart != null)
                        {
                            break;
                        }
                    }

                    if (chart == null)
                    {
                        Console.WriteLine("No chart found on the slide.");
                        return;
                    }

                    // Verify that the chart is a doughnut type
                    if (!ChartTypeCharacterizer.IsChartTypeDoughnut(chart.Type))
                    {
                        Console.WriteLine("The chart is not a doughnut chart.");
                        return;
                    }

                    // Apply callout annotation to the first data point of the first series
                    IChartSeries series = chart.ChartData.Series[0];
                    IChartDataPoint dataPoint = series.DataPoints[0];
                    IDataLabel dataLabel = dataPoint.Label;
                    dataLabel.DataLabelFormat.ShowLabelAsDataCallout = true;
                    dataLabel.DataLabelFormat.ShowLeaderLines = true; // optional visual aid

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}