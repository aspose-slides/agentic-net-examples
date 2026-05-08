using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add a Pie of Pie chart (use float literals for dimensions)
                IChart chart = slide.Shapes.AddChart(ChartType.PieOfPie, 0f, 0f, 500f, 400f);

                // Access the first series (the chart is initialized with sample data)
                IChartSeries series = chart.ChartData.Series[0];

                // Set the split type to Custom
                series.ParentSeriesGroup.PieSplitBy = PieSplitType.Custom;

                // Define a custom split position (e.g., 30.0)
                series.ParentSeriesGroup.PieSplitPosition = 30.0;

                // Optionally adjust the size of the second pie (e.g., 80%)
                series.ParentSeriesGroup.SecondPieSize = 80;

                // Save the presentation
                pres.Save("PieOfPie_CustomSplit.pptx", SaveFormat.Pptx);
            }
        }
    }
}