using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace DoughnutChartModification
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation("input.pptx"))
                {
                    // Access the first slide
                    ISlide slide = pres.Slides[0];

                    // Assume the first shape is a doughnut chart
                    IChart chart = (IChart)slide.Shapes[0];

                    // Adjust the first slice angle of the doughnut chart
                    chart.ChartData.Series[0].ParentSeriesGroup.FirstSliceAngle = 45;

                    // Adjust the doughnut hole size (0-90 percent)
                    chart.ChartData.Series[0].ParentSeriesGroup.DoughnutHoleSize = 50;

                    // Iterate through each series to modify data points and colors
                    for (int s = 0; s < chart.ChartData.Series.Count; s++)
                    {
                        IChartSeries series = chart.ChartData.Series[s];

                        // Clear existing data points
                        series.DataPoints.Clear();

                        // Add new data points for the doughnut series
                        series.DataPoints.AddDataPointForDoughnutSeries(30);
                        series.DataPoints.AddDataPointForDoughnutSeries(70);

                        // Set colors for each data point
                        for (int p = 0; p < series.DataPoints.Count; p++)
                        {
                            IChartDataPoint point = series.DataPoints[p];
                            point.Format.Fill.FillType = FillType.Solid;

                            if (p == 0)
                            {
                                point.Format.Fill.SolidFillColor.Color = Color.Red;
                            }
                            else
                            {
                                point.Format.Fill.SolidFillColor.Color = Color.Blue;
                            }
                        }
                    }

                    // Save the modified presentation
                    pres.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}