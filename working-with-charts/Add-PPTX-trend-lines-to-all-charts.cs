using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AddTrendLinesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                Presentation pres = new Presentation("input.pptx");

                // Iterate through all slides
                foreach (ISlide slide in pres.Slides)
                {
                    // Iterate through all shapes on the slide
                    foreach (IShape shape in slide.Shapes)
                    {
                        // Check if the shape is a chart
                        if (shape is IChart)
                        {
                            IChart chart = (IChart)shape;

                            // Verify that the chart type supports series trend lines
                            if (ChartTypeCharacterizer.HasSeriesTrendLines(chart.Type))
                            {
                                // Iterate through each series in the chart
                                foreach (IChartSeries series in chart.ChartData.Series)
                                {
                                    // Add a linear trend line to the series
                                    series.TrendLines.Add(TrendlineType.Linear);
                                }
                            }
                        }
                    }
                }

                // Save the modified presentation
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}