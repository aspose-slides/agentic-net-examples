using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SkipChartsWithoutPlotArea
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            try
            {
                if (File.Exists(inputPath))
                {
                    // Load existing presentation
                    using (Presentation pres = new Presentation(inputPath))
                    {
                        // Iterate through all slides
                        foreach (ISlide slide in pres.Slides)
                        {
                            // Iterate through all shapes on the slide
                            foreach (IShape shape in slide.Shapes)
                            {
                                IChart chart = shape as IChart;
                                if (chart != null)
                                {
                                    // Skip charts that do not have a plot area
                                    if (chart.PlotArea == null)
                                    {
                                        continue;
                                    }

                                    // Add trendlines only if the chart type supports them
                                    if (ChartTypeCharacterizer.HasSeriesTrendLines(chart.Type))
                                    {
                                        // Iterate through each series in the chart
                                        foreach (IChartSeries series in chart.ChartData.Series)
                                        {
                                            // Add a linear trendline to the series
                                            series.TrendLines.Add(TrendlineType.Linear);
                                        }
                                    }
                                }
                            }
                        }

                        // Save the modified presentation
                        pres.Save(outputPath, SaveFormat.Pptx);
                    }
                }
                else
                {
                    // Create a new presentation if the input file does not exist
                    using (Presentation pres = new Presentation())
                    {
                        // Add a sample chart to demonstrate trendline addition
                        ISlide slide = pres.Slides[0];
                        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 400);

                        // Add trendlines if supported
                        if (ChartTypeCharacterizer.HasSeriesTrendLines(chart.Type))
                        {
                            foreach (IChartSeries series in chart.ChartData.Series)
                            {
                                series.TrendLines.Add(TrendlineType.Linear);
                            }
                        }

                        // Save the newly created presentation
                        pres.Save(outputPath, SaveFormat.Pptx);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported file formats or other errors
                // For unsupported formats, you may log or inform the user here
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}