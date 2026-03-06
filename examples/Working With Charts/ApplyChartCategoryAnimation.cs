using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace ApplyChartCategoryAnimation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output directory and file name
            string dataDir = "Data/";
            string outputChartFile = "AnimatedChart_out.pptx";

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            Slide slide = (Slide)presentation.Slides[0];

            // Add a clustered column chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 400);

            // Optional: clear default data and add custom categories/series if needed
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Example: add two categories
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));

            // Example: add one series with sample data
            IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, "B1", "Series 1"), chart.Type);
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, "B2", 10));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, "B3", 20));

            // Add a fade effect to the whole chart
            slide.Timeline.MainSequence.AddEffect(
                chart,
                EffectType.Fade,
                EffectSubtype.None,
                EffectTriggerType.AfterPrevious);

            // Get the main sequence as a Sequence object
            Sequence seq = (Sequence)slide.Timeline.MainSequence;

            // Get counts of categories and series
            int categoryCount = chart.ChartData.Categories.Count;
            int seriesCount = chart.ChartData.Series.Count;

            // Animate each element in each category
            for (int cat = 0; cat < categoryCount; cat++)
            {
                for (int ser = 0; ser < seriesCount; ser++)
                {
                    seq.AddEffect(
                        chart,
                        EffectChartMinorGroupingType.ByElementInCategory,
                        ser,
                        cat,
                        EffectType.Appear,
                        EffectSubtype.None,
                        EffectTriggerType.AfterPrevious);
                }
            }

            // Save the presentation
            presentation.Save(dataDir + outputChartFile, SaveFormat.Pptx);
        }
    }
}