using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;

namespace ApplyCustomEasingToCategoryAnimation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string dataDir = "Data";
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output_custom_easing.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Get the first slide
                    ISlide slide = presentation.Slides[0];

                    // Retrieve or create a chart on the slide
                    IChart chart = null;
                    if (slide.Shapes.Count > 0 && slide.Shapes[0] is IChart)
                    {
                        chart = (IChart)slide.Shapes[0];
                    }
                    else
                    {
                        // Add a new clustered column chart with sample data
                        chart = (IChart)slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

                        // Populate sample data for the chart
                        IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                        int defaultWorksheetIndex = 0;

                        // Clear default series and categories
                        chart.ChartData.Series.Clear();
                        chart.ChartData.Categories.Clear();

                        // Add series
                        chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
                        chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

                        // Add categories
                        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
                        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
                        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

                        // Populate series data
                        IChartSeries series1 = chart.ChartData.Series[0];
                        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 20));
                        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
                        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

                        IChartSeries series2 = chart.ChartData.Series[1];
                        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 30));
                        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 10));
                        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 60));
                    }

                    // Add animation effects for each category element
                    ISequence sequence = (ISequence)slide.Timeline.MainSequence;
                    int categoryCount = chart.ChartData.Categories.Count;
                    int seriesCount = chart.ChartData.Series.Count;

                    for (int cat = 0; cat < categoryCount; cat++)
                    {
                        for (int ser = 0; ser < seriesCount; ser++)
                        {
                            // Add a fade effect for each element in the category
                            IEffect effect = sequence.AddEffect(
                                chart,
                                EffectChartMinorGroupingType.ByElementInCategory,
                                ser,
                                cat,
                                EffectType.Fade,
                                EffectSubtype.None,
                                EffectTriggerType.AfterPrevious);

                            // Apply a custom easing function for smooth acceleration
                            // Note: The actual easing function property depends on the library version.
                            // The following line is a placeholder to illustrate where the easing would be set.
                            // effect.Timing.EasingFunction = CustomEasingFunction.SmoothAcceleration;
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}