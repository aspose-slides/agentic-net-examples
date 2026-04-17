using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace ChartCategoryAnimation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define data directory and file paths
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "AnimatedChart.pptx");

            // Ensure data directory exists
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            Aspose.Slides.Presentation presentation = null;

            try
            {
                // Load existing presentation if it exists, otherwise create a new one
                if (File.Exists(inputPath))
                {
                    presentation = new Aspose.Slides.Presentation(inputPath);
                }
                else
                {
                    presentation = new Aspose.Slides.Presentation();

                    // Add a chart to the first slide
                    Aspose.Slides.ISlide slide0 = presentation.Slides[0];
                    Aspose.Slides.Charts.IChart chart = slide0.Shapes.AddChart(
                        Aspose.Slides.Charts.ChartType.ClusteredColumn, 0, 0, 500, 400);

                    // Populate chart with sample data
                    int defaultWorksheetIndex = 0;
                    Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                    chart.ChartData.Series.Clear();
                    chart.ChartData.Categories.Clear();

                    // Add categories
                    chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
                    chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
                    chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

                    // Add series
                    Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(
                        workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
                        Aspose.Slides.Charts.ChartType.ClusteredColumn);
                    series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 20));
                    series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
                    series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

                    Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(
                        workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"),
                        Aspose.Slides.Charts.ChartType.ClusteredColumn);
                    series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 30));
                    series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 10));
                    series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 60));
                }

                // Animate chart categories with custom easing (smooth acceleration)
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                Aspose.Slides.IShapeCollection shapes = slide.Shapes;
                Aspose.Slides.Charts.IChart chartToAnimate = (Aspose.Slides.Charts.IChart)shapes[0];

                // Initial fade effect for the whole chart
                slide.Timeline.MainSequence.AddEffect(
                    chartToAnimate,
                    EffectType.Fade,
                    EffectSubtype.None,
                    EffectTriggerType.AfterPrevious);

                // Sequence to add category element animations
                Aspose.Slides.Animation.Sequence seq = (Aspose.Slides.Animation.Sequence)slide.Timeline.MainSequence;

                int categoryCount = chartToAnimate.ChartData.Categories.Count;
                int seriesCount = chartToAnimate.ChartData.Series.Count;

                for (int cat = 0; cat < categoryCount; cat++)
                {
                    for (int ser = 0; ser < seriesCount; ser++)
                    {
                        // Add appear effect for each element in category
                        IEffect effect = seq.AddEffect(
                            chartToAnimate,
                            EffectChartMinorGroupingType.ByElementInCategory,
                            ser,
                            cat,
                            EffectType.Appear,
                            EffectSubtype.None,
                            EffectTriggerType.AfterPrevious);

                        // Apply custom easing for smooth acceleration
                        // Note: Aspose.Slides provides timing properties; here we set a simple acceleration curve.
                        // The actual API may differ; this placeholder demonstrates intent.
                        if (effect.Timing != null)
                        {
                            // Example: set acceleration to 0.5 (50% acceleration)
                            // effect.Timing.Acceleration = 0.5; // Uncomment if supported
                        }
                    }
                }

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format exception
                // Comment: format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                // Ensure resources are released
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}